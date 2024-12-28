// Set up the .NET WebAssembly runtime
import { dotnet } from './dotnet.js'

// Get exported methods from the .NET assembly
const { getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

// Access JSExport methods using exports.<Namespace>.<Type>.<Method>
const result = exports.Lib.CreateLabel("^XA^FT100,100^A0N,67,0^FDTestLabel^FS^XZ", 300, 300, 8);

// Display the result of the .NET method
document.getElementById("out").innerHTML = `Result: ${result}`;