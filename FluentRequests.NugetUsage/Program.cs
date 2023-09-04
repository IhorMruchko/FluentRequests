// See https://aka.ms/new-console-template for more information
using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.Extensions;
using FluentRequests.Lib.Registering;

var register = new Register().Add(cb => cb.WithName("Add")
    .WithHelp("Adds help.")
    .AddOverload(ob => ob.WithHelp("Adds two items").WithRequired<int>(rb => rb.WithName("a")
                                                                               .WithHelp("First Element")
                                                                               .UseDefaultConverter()
                                                                               .Instatniate()
                                                                               .EndInit())
    .WithRequired<int>(rb => rb.WithName("b").WithHelp("Second Element").UseDefaultConverter().Instatniate().EndInit())
    .WithBody((req, opt) => (req.ValueOf<int>("a") + req.ValueOf<int>("b")).ToString()).EndInit())
    .EndInit());


while (true)
{
    Console.WriteLine(register.Execute(Console.ReadLine()?.Split() ?? Array.Empty<string>()));
}