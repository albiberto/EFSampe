using EFSample;
using EFSample.Domain;
using Microsoft.EntityFrameworkCore;

await using var context = new MyContext();
await context.Database.MigrateAsync();

var fruit = await context.Categories.AddAsync(new("Fruit", "Delicious"));
await context.SaveChangesAsync();

var fruitId = fruit.Entity.Id;

var categories = await context.Categories.ToListAsync();Console.WriteLine("Start");
Log(categories);

var apple = await context.Categories.AddAsync(new("Apple", "Red", fruitId));
await context.SaveChangesAsync();

Console.WriteLine("Added Apple to Fruit");
Log(categories);

var toDelete = await context.Categories.FindAsync(apple.Entity.Id);
context.Categories.Remove(toDelete!);
await context.SaveChangesAsync();

Console.WriteLine("Removed Apple from Fruit");
Log(categories);

Console.WriteLine("Done!");
Console.ReadKey();

void Log(ICollection<Category> categories)
{
    Console.WriteLine();
    Console.WriteLine("Categories:");
    Console.WriteLine();

    foreach (var category in categories)
    {
        Console.WriteLine(category.ToString());
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Child Categories:");
    Console.WriteLine();

    foreach (var category in categories.SelectMany(category => category.Categories))
    {
        Console.WriteLine(category.ToString());
        Console.WriteLine();
    }
}

        

