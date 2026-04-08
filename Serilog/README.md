In Godot 4, on main thread and all hooks (calls into virtual methods)
    all exception are cought before being printed by `ExceptionUtils.cs`
    via regular `GD.PrintErr(ex.ToString())` call.  
    This means that all exceptions are technically handled,
    so no event to subscribe to.
    But Godot 4 has Logging API so we can subscribe to what is essentially 
    an implementation of `GD.PrintErr` and redirect it back 
    to the good old Serilog.


## Most useful files

`Root.cs` is the entry point, with static ctor for setup.

`GodotSerilogLogger.cs` is the hacky workaround for Godot -> Serilog flow.

`log20260408.txt` is here specifically as an output example.
