// ---------------------------------------------Continue---------------------------------------------

string[][] orders =
[
    ["Keyboard", "Mouse"],
    ["Monitor", "OUT_OF_STOCK", "Cable"],
    ["Headphones"]
];

// // C# 15

// nextOrder:
// foreach (string[] order in orders)
// {
//     Console.WriteLine("New order:");

//     foreach (string item in order)
//     {
//         if (item == "OUT_OF_STOCK")
//         {
//             Console.WriteLine("  Item missing, skipping this order.");
//             continue nextOrder; // jump to the next ORDER, not the next item
//         }

//         Console.WriteLine($"  Packing {item}");
//     }

//     Console.WriteLine("  Order shipped!");
// }

// // Before C# 15

// foreach (string[] order in orders)
// {
//     Console.WriteLine("New order:");
//     bool skipOrder = false;

//     foreach (string item in order)
//     {
//         if (item == "OUT_OF_STOCK")
//         {
//             Console.WriteLine("  Item missing, skipping this order.");
//             skipOrder = true;
//             break; // step 1: get out of the inner loop...
//         }

//         Console.WriteLine($"  Packing {item}");
//     }

//     if (skipOrder)
//         continue; // step 2: ...then skip the rest of the outer loop

//     Console.WriteLine("  Order shipped!");
// }

// ---------------------------------------------Break---------------------------------------------

// // C# 15

// string[] commands = ["move", "jump", "quit", "move"];

// gameLoop:
// foreach (string command in commands)
// {
//     switch (command)
//     {
//         case "move":
//             Console.WriteLine("Moving...");
//             break; // exits the switch only

//         case "jump":
//             Console.WriteLine("Jumping...");
//             break; // exits the switch only

//         case "quit":
//             Console.WriteLine("Quitting the game.");
//             break gameLoop; // exits the whole loop
//     }
// }