# MonoInjectConsole
A front-end console made to comunicate with dlls injected into unity games.  

## Usage
After compilation, create in the same path as the MonoInjectConsole executable a file named `inject.bat`.  
Example of `inject.bat`:  
```
MonoJunkie.exe -dll "DllToInject.dll" -namespace MyNamespace -class MyClass -method MyMethodOnLoad -exe ProcessName.exe -mdll mono-2.0-bdwgc.dll
```
The content of this file must be a valid call to [MonoJunkie](https://github.com/wledfor2/MonoJunkie). If you encounter issues compiling, check my [MonoJunkie](https://github.com/eduardopietre/MonoJunkie) fork.  
MonoJunkie and the DllToInject must be in the same folder as the MonoInjectConsole executable.  
`-mdll mono-2.0-bdwgc.dll` sets the mono dll to `mono-2.0-bdwgc.dll`. It must be equal to the mono.dll name of the injected process.

## Screenshot
<img src="images/Example MonoInjectConsole Image.jpg">
