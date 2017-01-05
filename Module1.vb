Module Module1
    Public Team1 As String
    Public Team2 As String
    Public Team1Score As Integer
    Public Team2Score As Integer
    Public Rand As New Random
    Public RandomWinner As Integer = Rand.Next(0, 101)
    Public Sub Main()
        Console.WriteLine("Welcome to the CSGO score prediction maker!" & vbCrLf & "Is overtime possible in the game you want to predict? Y/N")
        Dim Overtime As String = Console.ReadLine
        While Overtime <> "Y" And Overtime <> "N"
            Console.Clear()
            Console.WriteLine("That is not valid, please try again now.")
            Overtime = Console.ReadLine
        End While
        Console.WriteLine("Please enter the name of the first team now.")
        Team1 = Console.ReadLine
        Console.WriteLine("Please enter the name of the second team now.")
        Team2 = Console.ReadLine
        If Overtime = "Y" Then
            OvertimeTrue()
        End If

        If Overtime = "N" Then
            OvertimeFalse()
        End If
    End Sub
    Sub OvertimeTrue()
        Console.Clear()
        Console.WriteLine("What format will the overtime be?" & vbCrLf & "1. MR6" & vbCrLf & "2. MR10")
        Dim OvertimeFormat As String = Console.ReadLine
        While OvertimeFormat <> "1" And OvertimeFormat <> "2"
            Console.WriteLine("That is not valid, please try again now.")
            OvertimeFormat = Console.ReadLine
        End While
        Dim OvertimeChance As Integer
        OvertimeChance = Rand.Next(75, 101)
        If OvertimeChance > 75 Then
            If OvertimeFormat = "1" Then
                Dim OvertimeWinsChance As Integer = Rand.Next(0, 101)
                Dim OvertimeMaxRounds = 19
                Dim OvertimeMinRounds = 15
                If OvertimeWinsChance <= 80 Then
                    OvertimeMaxRounds = 19
                    OvertimeMinRounds = 15
                End If
                If OvertimeWinsChance > 80 And OvertimeWinsChance <= 90 Then
                    OvertimeMaxRounds = 22
                    OvertimeMinRounds = 18
                End If
                If OvertimeWinsChance > 90 And OvertimeWinsChance <= 95 Then
                    OvertimeMaxRounds = 25
                    OvertimeMinRounds = 21
                End If
                If OvertimeWinsChance > 95 And OvertimeWinsChance <= 100 Then
                    OvertimeMaxRounds = 28
                    OvertimeMinRounds = 24
                End If
                While Team1Score <> OvertimeMaxRounds Or Team2Score <> OvertimeMaxRounds
                    Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
                    Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
                End While
                If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds Then
                    If RandomWinner > 50 Then
                        Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
                        Team2Score = OvertimeMaxRounds
                    Else
                        Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
                        Team1Score = OvertimeMaxRounds
                    End If
                End If
                If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds - 1 Then
                    Team2Score = OvertimeMaxRounds - 2
                End If
                If Team1Score = OvertimeMaxRounds - 1 And Team2Score = OvertimeMaxRounds Then
                    Team1Score = OvertimeMaxRounds - 2
                End If
            Else
                Dim OvertimeWinsChance As Integer = Rand.Next(0, 101)
                Dim OvertimeMaxRounds = 21
                Dim OvertimeMinRounds = 15
                If OvertimeWinsChance <= 80 Then
                    OvertimeMaxRounds = 21
                    OvertimeMinRounds = 15
                End If
                If OvertimeWinsChance > 80 And OvertimeWinsChance <= 90 Then
                    OvertimeMaxRounds = 26
                    OvertimeMinRounds = 20
                End If
                If OvertimeWinsChance > 90 And OvertimeWinsChance <= 95 Then
                    OvertimeMaxRounds = 31
                    OvertimeMinRounds = 25
                End If
                If OvertimeWinsChance > 95 And OvertimeWinsChance <= 100 Then
                    OvertimeMaxRounds = 36
                    OvertimeMinRounds = 30
                End If
                While Team1Score <> OvertimeMaxRounds Or Team2Score <> OvertimeMaxRounds
                    Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
                    Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
                End While
                If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds Then
                    If RandomWinner > 50 Then
                        Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
                        Team2Score = OvertimeMaxRounds
                    Else
                        Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
                        Team1Score = OvertimeMaxRounds
                    End If
                End If
                If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds - 1 Then
                    Team2Score = OvertimeMaxRounds - 2
                End If
                If Team1Score = OvertimeMaxRounds - 1 And Team2Score = OvertimeMaxRounds Then
                    Team1Score = OvertimeMaxRounds - 2
                End If
            End If
        End If
        Dim Winner As String
        If Team1Score > Team2Score Then
            Winner = Team1
        Else
            Winner = Team2
        End If
        If Team1Score = Team2Score Then
            Winner = "Draw"
        End If
        If Winner <> "Draw" Then
            Console.WriteLine("The winner is {0}.", Winner)
        Else
            Console.WriteLine("The game ended as a draw.")
        End If
        If Winner = Team1 Then
            Console.WriteLine("The score ended as {0} - {1}.", Team1Score, Team2Score)
        Else
            Console.WriteLine("The score ended as {0} - {1}.", Team2Score, Team1Score)
        End If
        Console.ReadLine()
    End Sub
    Sub OvertimeFalse()
        While Team1Score <> 16 Or Team2Score <> 16
            Team1Score = Rand.Next(0, 17)
            Team2Score = Rand.Next(0, 17)
            If Team1Score = 15 And Team2Score = 15 Then
                Exit While
            End If
        End While
        If Team1Score = 16 And Team2Score = 16 Then
            If RandomWinner > 50 Then
                Team1Score = Rand.Next(0, 15)
            Else
                Team2Score = Rand.Next(0, 15)
            End If
        End If
        If Team1Score = 16 And Team2Score = 15 Then
            Team2Score = 14
        End If
        If Team1Score = 15 And Team2Score = 16 Then
            Team1Score = 14
        End If
        Dim Winner As String
        If Team1Score > Team2Score Then
            Winner = Team1
        Else
            Winner = Team2
        End If
        If Team1Score = Team2Score Then
            Winner = "Draw"
        End If
        If Winner <> "Draw" Then
            Console.WriteLine("The winner is {0}.", Winner)
        Else
            Console.WriteLine("The game ended as a draw.")
        End If
        If Winner = Team1 Then
            Console.WriteLine("The score ended as {0} - {1}.", Team1Score, Team2Score)
        Else
            Console.WriteLine("The score ended as {0} - {1}.", Team2Score, Team1Score)
        End If
        Console.ReadLine()
    End Sub
End Module
