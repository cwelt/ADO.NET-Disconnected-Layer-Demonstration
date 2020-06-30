# ADO.NET-Disconnected-Layer-Demonstration :unlock:

Miniature desktop application for demonstrating the ADO.NET disconnected layer access to databases.  

The application demonstrates the usage of  [data adapters](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dataadapter?view=netcore-3.1#remarks), 
[datasets](https://docs.microsoft.com/en-us/dotnet/api/system.data.dataset?view=netcore-3.1#remarks),
[data tables](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netcore-3.1#remarks)  
and the interaction between them,
while constantly displaying the 
[connection state](https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.state?view=dotnet-plat-ext-3.1#remarks) (opened/closed),  
with an option to display the [row state](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/row-states-and-row-versions)
that is maintained by the [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html),  
and serializing and deseriailzing the data & schema to/from XML and XSD files.

