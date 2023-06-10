using FluentRequests.Lib.Attributes.RoutingAttributes;
using System;

namespace FluentRequests.Lib.BuiltInCommands
{
    [Command("console")]
    [Help("Provides access to the console functions.")]
    public class ConsoleCommand
    {
        [Command("cls")]
        [Help("Cleans console.")]
        public class ClearConsole
        {
            [Overload]
            [Help("Cleans console.")]
            public static string CleanConsole()
            {
                Console.Clear();
                return string.Empty;
            }
        }

        [Command("color")]
        [Help("Handle color of the console")]
        public class ColorHandling
        {
            [Command("foreground")]
            [Help("Provides access to the foreground console color")]
            public class ForeColorHandling
            {
                private static bool _isForegroundSet;
                private static ConsoleColor _foreground;

                private static ConsoleColor Foreground
                {
                    get => _foreground;
                    set
                    {
                        if (_isForegroundSet)
                            return;
                        _foreground = value;
                        _isForegroundSet = true;
                    }
                }

                [Overload]
                [Help("Changes foreground color of the console.")]
                public static string ChangeForeColor([Help("New foreground color of the console")] ConsoleColor consoleColor,
                                                     [Help("Defines is console can be cleared")] bool cls = false)
                {
                    Foreground = Console.ForegroundColor;
                    Console.ForegroundColor = consoleColor;
                    if (cls)
                        Console.Clear();
                    return $"Console color is changed to {consoleColor}";
                }

                [Overload]
                [Help("Resets foreground color of the console.")]
                public static string ChangeForeColor([Help("Defines is console can be cleared")] bool cls = false)
                {
                    Console.ForegroundColor = Foreground;
                    if (cls)
                        Console.Clear();
                    return "Console foreground color was reset.";
                }
            }

            [Command("background")]
            [Help("Provides access to the foreground console color.")]
            public class BackColorHandling
            {
                private static bool _isBackgroundSet;
                private static ConsoleColor _background;

                private static ConsoleColor BackGround
                {
                    get => _isBackgroundSet ? _background : Console.BackgroundColor;
                    set
                    {
                        if (_isBackgroundSet)
                            return;
                        _background = value;
                        _isBackgroundSet = true;
                    }
                }

                [Overload]
                [Help("Changes background color of the console.")]
                public static string ChangeBackColor([Help("Color of the console background")] ConsoleColor background,
                                                     [Help("Defines is console can be cleared")] bool cls = false)
                {
                    BackGround = Console.BackgroundColor;
                    Console.BackgroundColor = background;
                    if (cls)
                        Console.Clear();
                    return $"Console background color was set to {background}";
                }

                [Overload]
                [Help("Resets background color for the console.")]
                public static string ChangeBackColor([Help("Defines is console can be cleared")] bool cls = false)
                {
                    Console.BackgroundColor = BackGround;
                    if (cls)
                        Console.Clear();
                    return $"Console background color was reset";
                }
            }

            [Command("reset")]
            [Help("Resets all color to defaults.")]
            public class ResetColor
            {
                [Overload]
                [Help("Resets all color to default console values.")]
                public static string ResetColors([Help("Defines is console can be cleared")] bool cls = false)
                {
                    Console.ResetColor();
                    if (cls)
                        Console.Clear();
                    return "All colors of the console was reset.";
                }
            }
        }
    }
}
