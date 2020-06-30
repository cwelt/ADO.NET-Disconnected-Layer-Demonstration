using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DisconnectedLayerDemonstration
{
    public partial class MainForm : Form
    {
        // Db entities declaration
        private DataSet _dataSet;
        private string _dataProvider;
        private DbConnection _connection;
        private string _connectionString;
        private DbProviderFactory _factory;

        private DbDataAdapter _generalAdapter;
        private DbDataAdapter _semestersAdapter;
        private DbDataAdapter _courseOfferingsAdapter;
        private DbDataAdapter _coursesAdapter;
        private DbDataAdapter _courseLevelsAdapter;
        private DbDataAdapter _coursePrerequisitesAdapter;
        private DbDataAdapter _enrollmentStatusesAdapter;
        private DbDataAdapter _enrollmentsAdapter;
        private DbDataAdapter _studentsAdapter;
        private List<DbDataAdapter> _dataAdapters;
        private List<DbCommandBuilder> _commandBuilders;

        // flag for RowState initialization
        private bool _firstInitialization = true;


        public MainForm()
        {
            InitializeComponent();

            // Suppress GUI cross-thread exceptions in debug mode
            Control.CheckForIllegalCrossThreadCalls = false;

            // get connection string from App.Config file
            _connectionString = ConfigurationManager.ConnectionStrings["GearHostDB"].ConnectionString;

            // get data provider from the App.Config file
            _dataProvider = ConfigurationManager.ConnectionStrings["GearHostDB"].ProviderName;

            /* use the abstract factory to get factory responsible 
             * for creating a family of related Db objects for this provider */
            _factory = DbProviderFactories.GetFactory(_dataProvider);


            // use a factory method to create a connection 
            _connection = _factory.CreateConnection();
            _connection.ConnectionString = _connectionString;

            // use abstract method to actually create the data adapters
            _studentsAdapter = _factory.CreateDataAdapter();
            _semestersAdapter = _factory.CreateDataAdapter();
            _courseLevelsAdapter = _factory.CreateDataAdapter();
            _coursesAdapter = _factory.CreateDataAdapter();
            _courseOfferingsAdapter = _factory.CreateDataAdapter();
            _coursePrerequisitesAdapter = _factory.CreateDataAdapter();
            _enrollmentStatusesAdapter = _factory.CreateDataAdapter();
            _enrollmentsAdapter = _factory.CreateDataAdapter();
            _generalAdapter = _factory.CreateDataAdapter();

            // fill list of empty data adapters 
            _dataAdapters = new List<DbDataAdapter>
            {
                _studentsAdapter,
                _semestersAdapter,
                _courseLevelsAdapter,
                _coursesAdapter,
                _courseOfferingsAdapter,
                _coursePrerequisitesAdapter,
                _enrollmentStatusesAdapter,
                _enrollmentsAdapter,
                _generalAdapter
            };

            // use abstract method to create the select commands for the adapters 
            for (int i = 0; i < _dataAdapters.Count; i++)
            {
                _dataAdapters[i].SelectCommand = _factory.CreateCommand();
                _dataAdapters[i].SelectCommand.Connection = _connection;
            }

            // configure the select command query objects for all adapters 
            _studentsAdapter.SelectCommand.CommandText = "SELECT * FROM Students;";
            _semestersAdapter.SelectCommand.CommandText = "SELECT * FROM Semesters;";
            _courseLevelsAdapter.SelectCommand.CommandText = "SELECT * FROM CourseLevels;";
            _coursesAdapter.SelectCommand.CommandText = "SELECT * FROM Courses;";
            _courseOfferingsAdapter.SelectCommand.CommandText = "SELECT * FROM CourseOfferings;";
            _coursePrerequisitesAdapter.SelectCommand.CommandText = "SELECT * FROM CoursePrerequisites;";
            _enrollmentStatusesAdapter.SelectCommand.CommandText = "SELECT * FROM EnrollmentStatuses;";
            _enrollmentsAdapter.SelectCommand.CommandText = "SELECT * FROM Enrollments;";
            _generalAdapter.SelectCommand.CommandText = "SELECT SemesterId, Courses.CourseId, CourseName, Students.StudentId, StudentName FROM Enrollments, Students, Courses WHERE Students.StudentId = Enrollments.StudentId AND Courses.CourseId = Enrollments.CourseId";

            // configure modification command objects via command builder 
            _commandBuilders = new List<DbCommandBuilder>(_dataAdapters.Count);
            for (int i = 0; i < _dataAdapters.Count - 1; i++)
            {
                var commandBuilder = _factory.CreateCommandBuilder();
                commandBuilder.DataAdapter = _dataAdapters[i];
                _commandBuilders.Add(commandBuilder);
            }

            // configure general adapter modification commands manually 
            _generalAdapter.InsertCommand = _factory.CreateCommand();
            _generalAdapter.InsertCommand.Connection = _connection;
            _generalAdapter.UpdateCommand = _factory.CreateCommand();
            _generalAdapter.UpdateCommand.Connection = _connection;
            _generalAdapter.DeleteCommand = _factory.CreateCommand();
            _generalAdapter.DeleteCommand.Connection = _connection;

            // add data adapters to display list 
            dataAdapterListBox.Items.AddRange(new[]{
                    "Students", "Semesters",  "Course Levels", "Courses", "Course Offerings",
                     "Course Prerequisites", "Enrollment Statuses", "Enrollments", "General"});

            // create an empty data set 
            _dataSet = new DataSet("University Dataset");



            // initially load data from all data adapters to all tables in the dataset
            foreach (var adapter in _dataAdapters)
            {
                DataTable dataTable = new DataTable();
                adapter.FillSchema(dataTable, SchemaType.Source);
                adapter.Fill(dataTable);
                _dataSet.Tables.Add(dataTable);
            }

            // initialy select the first adapter
            dataAdapterListBox.SelectedIndex = 0;

            // register event handler for connection change 
            _connection.StateChange += _connection_StateChange;

            // initially do not display the unit of work row state
            unitOfWorkCheckBox.Checked = false;

        }

        /// <summary>
        /// Event handler for connection change of state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void _connection_StateChange(object sender, StateChangeEventArgs e)
        {
            await Task.Run(() =>
            {
                /* if we are toggling into a closed connection implcitly via a data adapter, 
                 * create an artifical delay to emphasis the open connection */
                if (e.CurrentState == ConnectionState.Closed)
                    Thread.Sleep(1500);

                // update the display with the current connection state
                UpdateConnectionStatusDisplay(e.CurrentState);
            });
        }


        /// <summary>
        /// Refreshes data table of currently selected adapter and it's grid view
        /// </summary>
        private void LoadData()
        {
            try
            {
                // get the selected adapter
                int index = dataAdapterListBox.SelectedIndex;
                var adapter = _dataAdapters[index];

                // refresh table from data adapter
                adapter.FillSchema(_dataSet.Tables[index], SchemaType.Source);
                adapter.Fill(_dataSet.Tables[index]);
                DataTable resultTable = _dataSet.Tables[index];

                // update the view with updated data 
                mainDataGridView.DataSource = _dataSet.Tables[index];

                // style row state columns
                if (resultTable.Columns.Contains("RowState"))
                {
                    resultTable.Columns["RowState"].ReadOnly = true;
                    mainDataGridView.Columns["RowState"].DefaultCellStyle.BackColor = Color.Beige;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // get selected adapter 
            int index = dataAdapterListBox.SelectedIndex;
            _dataAdapters[index].SelectCommand.CommandText = selectTextBox.Text;

            /* if this adapter is table specific one, revalidate it's schema 
             * in case the select statement was modified */ 
            if (index < _dataAdapters.Count - 1)
                _commandBuilders[index].RefreshSchema();

            /* if this is the last general adapter, refresh it with new statement 
            * from text box */
            else
            {
                _dataSet.Tables.RemoveAt(index);
                _dataSet.Tables.Add(new DataTable());
            }

            // delegate the data load to the dedicated method
            LoadData();
        }


        /// <summary>
        /// Intervene in row validation event in order to update row state in 
        /// grid view controll according to the row state of the data rows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_firstInitialization)
                return;

            // get the underlying data table under the grid view controll
            DataTable table = mainDataGridView.DataSource as DataTable;

            // nothing to do if this table does not contain a row state 
            if (!table.Columns.Contains("RowState"))
                return;

            // update row state if necessary 
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string state = (table.Rows[i]["RowState"])?.ToString() ?? string.Empty;
                if (!state.Equals(table.Rows[i].RowState.ToString() ?? string.Empty))
                {
                    table.Columns["RowState"].ReadOnly = false;
                    table.Rows[i]["RowState"] = table.Rows[i].RowState;
                    table.Columns["RowState"].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// add a row state column behind the scenes and display it 
        /// only if the relavant check box is marked, 
        /// and style key columns of each table in a light blue color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainDataGridView_Paint(object sender, PaintEventArgs e)
        {
            _firstInitialization = false;

            // get the underlying data table and data set
            DataTable dataTable = mainDataGridView.DataSource as DataTable;
            DataSet dataset = (mainDataGridView.DataSource as DataTable).DataSet;

            // update row state column for all tables in data set 
            foreach (DataTable table in dataset.Tables)
            {
                // do nothing if the table already contain a row state column
                if (!dataTable.Columns.Contains("RowState"))
                {
                    // add a new column for displaying the row state
                    dataTable.Columns.Add("RowState", typeof(string));
                    dataTable.Columns["RowState"].ReadOnly = false;

                    // update the display value in the new column
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        dataRow["RowState"] = DataRowState.Unchanged.ToString();
                    }
                    dataTable.Columns["RowState"].ReadOnly = true;

                    /* reset state because after column update all row states are 
                     * modified... so reset all to "unchanged"... */ 
                    dataset.AcceptChanges();

                    // display/hide the data row column according to check box
                    if (unitOfWorkCheckBox.Checked)
                        mainDataGridView.Columns["RowState"].Visible = true;
                    else
                        mainDataGridView.Columns["RowState"].Visible = false;

                    // stlye the row state column
                    mainDataGridView.Columns["RowState"].DefaultCellStyle.BackColor = Color.Beige;
                }
            }

            // update style for key columns 
            foreach (DataColumn keyColumn in dataTable.PrimaryKey)
            {
                mainDataGridView.Columns[keyColumn.ColumnName].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        /// <summary>
        /// Removes selected rows from the data table (without deleting them).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // get underlying data table 
            DataTable dataTable = mainDataGridView.DataSource as DataTable;
            
            // get indices of the selected rows
            List<DataRow> selectedRows = new List<DataRow>();
            for (int i = 0; i < mainDataGridView.SelectedRows.Count; i++)
            {
                var selectedRow = mainDataGridView.SelectedRows[i];
                selectedRows.Add(dataTable.Rows[selectedRow.Index]);
            }

            // to the actual removal according to the found row indices
            foreach (var row in selectedRows)
            {
                dataTable.Rows.Remove(row);
            }
        }

        /// <summary>
        /// Updates the connection state display when form first loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateConnectionStatusDisplay(_connection.State);
        }

        /// <summary>
        /// Set Connection State Display
        /// </summary>
        /// <param name="state"></param>
        private void UpdateConnectionStatusDisplay(ConnectionState state)
        {
            lblConnection.Text = state.ToString();
            lblConnection.ForeColor = (state == ConnectionState.Open) ? Color.Red : Color.Green;
        }


        /// <summary>
        /// Opens/Closes a connection manually (toggles current state).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenCloseConnection_Click(object sender, EventArgs e)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            else _connection.Close();
        }


        /// <summary>
        /// Handles the Row State checkbox toggle event in order
        /// to display hide the row state column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unitOfWorkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (unitOfWorkCheckBox.Checked)
            {
                if (mainDataGridView.Columns.Contains("RowState"))
                    mainDataGridView.Columns["RowState"].Visible = true;
                else
                {
                    DataSet dataset = (mainDataGridView.DataSource as DataTable).DataSet;
                    foreach (DataTable dataTable in dataset.Tables)
                    {
                        dataTable.Columns.Add("RowState", typeof(string));
                        dataTable.Columns["RowState"].ReadOnly = false;
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            dataRow["RowState"] = dataRow.RowState.ToString();
                        }
                        dataTable.Columns["RowState"].ReadOnly = true;
                    }
                }

            }
            else
            {
                if (mainDataGridView.Columns.Contains("RowState"))
                {
                    mainDataGridView.Columns["RowState"].Visible = false;
                }
            }
        }

        /// <summary>
        /// Update adapters and display with data according to selected display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataAdapterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected adapter
            int selectedIndex = dataAdapterListBox.SelectedIndex;
            var dataAdapter = _dataAdapters[selectedIndex];

            // if this is a table specific adapter update statements from command builder
            DbCommandBuilder commandBuilder = null;
            if (selectedIndex < _dataAdapters.Count - 1)
            {
                commandBuilder = _commandBuilders[selectedIndex];
                insertTextBox.Text = commandBuilder?.GetInsertCommand().CommandText;
                updateTextBox.Text = commandBuilder?.GetUpdateCommand().CommandText;
                deleteTextBox.Text = commandBuilder?.GetDeleteCommand().CommandText;
            }

            // if this a generic adapter, just take the statements from the text boxes
            else
            {
                insertTextBox.Text = dataAdapter.InsertCommand.CommandText;
                updateTextBox.Text = dataAdapter.UpdateCommand.CommandText;
                deleteTextBox.Text = dataAdapter.DeleteCommand.CommandText;
            }

            selectTextBox.Text = dataAdapter.SelectCommand.CommandText;
            mainDataGridView.DataSource = _dataSet.Tables[selectedIndex];
        }

        /// <summary>
        /// Pushes changes from currently selected data adapter back to the data store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = dataAdapterListBox.SelectedIndex;
            var dataAdapter = _dataAdapters[index];
            dataAdapter.Update(_dataSet.Tables[index]);
        }

        /// <summary>
        /// Serialize entire data set to xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            // init file file dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML|*.xml";
            saveDialog.Title = "Save DataSet to XML File";
            saveDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (!string.IsNullOrWhiteSpace(saveDialog.FileName))
            {
                // Saves the XML via a FileStream created by the OpenFile method.
                FileStream fs = saveDialog.OpenFile() as FileStream;
                _dataSet.WriteXml(fs);

                // close the stream
                fs.Close();
            }
        }


        /// <summary>
        /// Serialize entire data set schema to XSD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteXmlSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XSD|*.xsd";
            saveDialog.Title = "Save DataSet Schema to XSD File";
            saveDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (!string.IsNullOrWhiteSpace(saveDialog.FileName))
            {
                // Saves the Schema xsd via a FileStream created by the OpenFile method.
                FileStream fs = saveDialog.OpenFile() as FileStream;
                _dataSet.WriteXmlSchema(fs);

                fs.Close();
            }
        }

        /// <summary>
        /// Desrealizes data from an external xml into a data set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog readDialog = new OpenFileDialog();
            readDialog.Filter = "XML|*.xml";
            readDialog.Title = "Load DataSet From XML File";
            readDialog.ShowDialog();

            // If the file name is not an empty string open it for reading.
            if (!string.IsNullOrWhiteSpace(readDialog.FileName))
            {
                // Loads the data via a FileStream created by the OpenFile method.
                FileStream fs = readDialog.OpenFile() as FileStream;
                _dataSet.ReadXml(fs, XmlReadMode.ReadSchema);
                fs.Close();
            }
        }

        /// <summary>
        /// Clears all data from entire dataset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            _dataSet.Clear();
        }

        /// <summary>
        /// Removes selected rows from the displayed view AND deletes them 
        /// from the underlying data source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dataTable = mainDataGridView.DataSource as DataTable;

            // get selected rows from grid view
            List<DataRow> selectedRows = new List<DataRow>();
            for (int i = 0; i < mainDataGridView.SelectedRows.Count; i++)
            {
                var selectedRow = mainDataGridView.SelectedRows[i];
                selectedRows.Add(dataTable.Rows[selectedRow.Index]);
            }

            // delete them
            foreach (var row in selectedRows)
            {
                row.Delete();
            }

            // commit change to data to all deleted rows
            _dataAdapters[dataAdapterListBox.SelectedIndex].Update(selectedRows.ToArray());
            
            // refresh display view
            mainDataGridView.Refresh();
        }
    }
}
