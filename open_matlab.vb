Imports System
Module open_matlab
    ' connect to a opened matlab session
    ' TODO: for end while end switch end try end if end
    ' TODO: Multiple Line Input
    Sub Main()
        Dim h As Object
        Dim res As String
        Dim matcmd As String
        
        h = GetObject(, "Matlab.Application")
        Console.WriteLine("MATLAB & Notepad++")
        Console.WriteLine(" ")
        'mainLoop
        while True
            Console.Write(">> ")
            matcmd = Console.ReadLine()
            ' How you exit this app
            if matcmd.Equals("!!") then
                Exit while
            End if
            res=h.Execute(matcmd)
            Console.WriteLine(res)
        End while
    End Sub
End Module