./main : ./Main.cs ./PrimesLib.dll
	csc -reference:PrimesLib.dll Main.cs

./PrimesLib.dll : ./PrimesLib.cs
	csc -target:library PrimesLib.cs

clean :
	rm ./Main.exe
	rm ./PrimesLib.dll

