Imports System
Imports System.Collections
Module open_matlab
    ' connect to a opened matlab session
    ' TODO: for end while end switch end try end if end
    ' TODO: Multiple Line Input
    Sub Main()
        Dim h As Object
        Dim res As String
        Dim matcmd As String
        Dim head As String()
        Dim sig_st As Stack = New Stack()
        Dim longcmd As String
        
        h = GetObject(, "Matlab.Application")
        Console.WriteLine("MATLAB & Notepad++")
        Console.WriteLine(" ")
        'mainLoop
        while True
            Console.Write(">> ")
            longcmd = ""
            sig_st.Clear()
            while True
                matcmd = Console.ReadLine()
                
                if longcmd.Equals("") then
                    longcmd = matcmd
                Else
                    longcmd = String.Concat(longcmd,";",matcmd)
                End if
                head = matcmd.Split({" "c})
                Select head(0)
                    case "for","while","try","if","switch"
                        sig_st.Push("+")
                    case "end"
                        sig_st.Pop()
                End Select
                if (0 = sig_st.Count) then
                    Exit while
                End if
            End while
            ' How you exit this app
            if longcmd.Equals("!!") then
                Exit while
            End if
            res=h.Execute(longcmd)
            Console.WriteLine(res)
        End while
    End Sub
    
    
End Module