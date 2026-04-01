using System.Linq;
using Godot;
using Godot.Collections;
using Serilog;

namespace SerilogLogging;

public partial class GodotSerilogLogger : Logger
{
    /// <inheritdoc/>
    /// <remarks>
    /// Most of these parameters are useless, since GD.PushError() is called from ExceptionUtils.LogException.
    /// Only <see cref="code"/> has what was returned by <see cref="System.Exception.ToString"/>.
    /// </remarks>
    public override void _LogError(string function, string file, int line, string code, string rationale,
        bool editorNotify, 
        int errorType,
        Array<ScriptBacktrace> scriptBacktraces)
    {
        Log.Error("An unhandled exception occured!\n{Code}", code);
    }

    /// <inheritdoc/>
    public override void _LogMessage(string message, bool error)
    {
        if (error)
        {
            Log.Error("{ErrorMessage}", message);
        }
        else
        {
            Log.Warning("{Message}", message);
        }
    }
}