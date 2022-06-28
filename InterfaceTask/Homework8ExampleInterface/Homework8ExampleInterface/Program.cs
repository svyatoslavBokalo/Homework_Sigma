// See https://aka.ms/new-console-template for more information
using Homework8ExampleInterface;

Console.WriteLine("Hello, World!");


IMoveAtom moveAtom = new GiometricVectorAtom(1, 10);
Console.WriteLine($"moveAtom = {moveAtom}");
moveAtom.MoveAtom();
Console.WriteLine(moveAtom);


//moveAtom = new GiometricVectorMove(1, 10); // так робити не можна


Console.WriteLine();
moveAtom = new GiometricVectorMoveDerive(1, 10);
moveAtom.MoveAtom();
Console.WriteLine(moveAtom);
(moveAtom as IMoveDerive).Move(3);
Console.WriteLine(moveAtom);


Console.WriteLine();
ITurn turn = new GiometricVectorTurn(1, 10);
Console.WriteLine(turn);
turn.MoveAtom();
Console.WriteLine(turn);
turn.Turn();
Console.WriteLine(turn);

Console.WriteLine();
IComplexMove complexMove = new GiometricVectorComplex(1, 10);
Console.WriteLine(complexMove);
complexMove.MoveAtom();
Console.WriteLine(complexMove);
complexMove.Turn();
Console.WriteLine(complexMove);

//Console.WriteLine();
//turn = complexMove; // так не можна
