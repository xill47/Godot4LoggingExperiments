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
        ExceptionButton.Pressed += ExceptionButtonOnPressed;
        WarningButton.Pressed += WarningButtonOnPressed;
    }

    private void ExceptionButtonOnPressed()
    {
        throw new Exception("This is an exception");
    }

    private void WarningButtonOnPressed()
    {
        logger.Warning("This is a warning");
    }
}