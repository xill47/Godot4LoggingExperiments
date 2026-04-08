using System;
using Godot;
using Serilog;

namespace SerilogLogging;

[SceneTree("root.tscn")]
public partial class Root : Control
{
    static Root()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Warning()
            .CreateLogger();
        OS.AddLogger(new GodotSerilogLogger());
    }
   
    private ILogger logger = Log.ForContext<Root>();

    public override void _Ready()
    {
        ExceptionButton.Pressed += () => throw new Exception("This is an exception");
        SerilogWarningButton.Pressed += () => logger.Warning("This is a warning");
        SerilogErrorButton.Pressed += () => logger.Error("This is an error");
        GodotWarningButton.Pressed += () => GD.PushWarning("This is a Godot warning");
        GodotErrorButton.Pressed += () => GD.PushError("This is a Godot error");
    }
}