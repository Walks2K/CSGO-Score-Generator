Module Module1
    Public Team1 As String
    Public Team2 As String
    Public Team1Score As Integer
    Public Team2Score As Integer
    Public Rand As New Random
    Public RandomWinner As Integer = Rand.Next(0, 101)
    Public HalfTimeEnabled As Boolean = True
    Public MapPool(6) As String
    Public Sub Main()
        Console.Clear()
        RandomWinner = Rand.Next(0, 101)
        Team1Score = 0
        Team2Score = 0
        Team1 = ""
        Team2 = ""
        MapPool(0) = "Cache"
        MapPool(1) = "Cobblestone"
        MapPool(2) = "Dust 2"
        MapPool(3) = "Mirage"
        MapPool(4) = "Nuke"
        MapPool(5) = "Overpass"
        MapPool(6) = "Train"
        Dim ScrambledMapPool(6) As String
        For i = 0 To 6
            Dim RandomMap As Integer
                RandomMap = Rand.Next(0, 7)
                While ScrambledMapPool.Contains(MapPool(RandomMap))
                    RandomMap = Rand.Next(0, 7)
                End While
                ScrambledMapPool(i) = MapPool(RandomMap)
        Next
        Console.WriteLine("Welcome to the CSGO score prediction maker!" & vbCrLf & "What would you like to do?")
        Console.WriteLine("1. Setup Game")
        Console.WriteLine("2. Configure Options")
        Dim UserChoice As String = Console.ReadLine
        Select Case UserChoice
            Case 1
                GameSetup()
            Case 2
                Configure()
            Case Else
                Main()
        End Select
    End Sub
    Sub Configure()
        Console.Clear()
        Console.WriteLine("1. Half Time Enabled: {0}", HalfTimeEnabled)
        Console.WriteLine("9. Home")

        Dim UserChoice As String = Console.ReadLine
        Select Case UserChoice
            Case 1
                If HalfTimeEnabled = True Then
                    HalfTimeEnabled = False
                Else
                    HalfTimeEnabled = True
                End If
                Configure()
            Case 9
                Main()
        End Select
    End Sub
    Sub GameSetup()
        Console.Clear()
        Console.WriteLine("Is overtime possible in the game you want to predict? Y/N")
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

        Console.Clear()

        If OvertimeFormat = "1" Then
            'Winning Scores
            Dim WinningScores(10) As Integer
            WinningScores(0) = "16"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                WinningScores(WinningScoresLoop) = 16 + (3 * WinningScoresLoop)
            Next

            'Max Rounds // DEPRECATED
            Dim MaxRounds(10) As Integer
            MaxRounds(0) = "30"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                MaxRounds(WinningScoresLoop) = 30 + (6 * WinningScoresLoop)
            Next

            'Half times
            Dim HalfTimes(10) As Integer
            HalfTimes(0) = "16"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                HalfTimes(WinningScoresLoop) = 30 + (3 * WinningScoresLoop)
            Next

            'Start game
            Dim i As Integer = 0
            Do Until WinningScores.Contains(Team1Score) AndAlso Team2Score < Team1Score - 1 Or WinningScores.Contains(Team2Score) AndAlso Team1Score < Team2Score - 1
                i = i + 1
                'Wait between round beginnings and endings
                If i > 1 Then
                    Console.WriteLine("")
                    System.Threading.Thread.Sleep(Rand.Next(500, 2001))
                End If
                'Halftime logic
                If HalfTimes.Contains(i) And HalfTimeEnabled = True Then
                    Dim Timer As Integer = 5
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    Console.Clear()
                    Console.WriteLine("Breaking for half time...")
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    For HalfTimeCount = 1 To 5
                        Console.WriteLine("Resuming in {0}...", Timer)
                        System.Threading.Thread.Sleep(1000)
                        Timer = Timer - 1
                        If HalfTimeCount = 5 Then
                            Console.Clear()
                        End If
                    Next
                End If
                'Begin round + round mechanics
                RandomWinner = Rand.Next(0, 101)
                If Team1Score = 45 And Team2Score < 45 Then
                    RandomWinner = 100
                End If
                If Team2Score = 45 And Team1Score < 45 Then
                    RandomWinner = 0
                End If
                Console.WriteLine("The round has begun...")
                System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
                If RandomWinner > 50 Then
                    Team1Score = Team1Score + 1
                    Console.WriteLine("{0} has taken the round.", Team1)
                    Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
                Else
                    Team2Score = Team2Score + 1
                    Console.WriteLine("{0} has taken the round.", Team2)
                    Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
                End If
            Loop

            System.Threading.Thread.Sleep(Rand.Next(500, 1501))
            DetermWin()
        Else
            'Winning Scores
            Dim WinningScores(10) As Integer
            WinningScores(0) = "16"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                WinningScores(WinningScoresLoop) = 16 + (5 * WinningScoresLoop)
            Next

            'Max Rounds // DEPRECATED
            Dim MaxRounds(10) As Integer
            MaxRounds(0) = "30"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                MaxRounds(WinningScoresLoop) = 30 + (10 * WinningScoresLoop)
            Next

            'Half times
            Dim HalfTimes(10) As Integer
            HalfTimes(0) = "16"
            For WinningScoresLoop As Integer = 1 To 10 Step 1
                HalfTimes(WinningScoresLoop) = 30 + (5 * WinningScoresLoop)
            Next

            'Start game
            Dim i As Integer = 0
            Do Until WinningScores.Contains(Team1Score) Or WinningScores.Contains(Team2Score)
                i = i + 1
                'Wait between round beginnings and endings
                If i > 1 Then
                    Console.WriteLine("")
                    System.Threading.Thread.Sleep(Rand.Next(500, 2001))
                End If
                'Halftime logic
                If HalfTimes.Contains(i) And HalfTimeEnabled = True Then
                    Dim Timer As Integer = 5
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    Console.Clear()
                    Console.WriteLine("Breaking for half time...")
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    For HalfTimeCount = 1 To 5
                        Console.WriteLine("Resuming in {0}...", Timer)
                        System.Threading.Thread.Sleep(1000)
                        Timer = Timer - 1
                        If HalfTimeCount = 5 Then
                            Console.Clear()
                        End If
                    Next
                End If
                'Begin round + round mechanics
                RandomWinner = Rand.Next(0, 101)
                If Team1Score = 45 And Team2Score < 45 Then
                    RandomWinner = 100
                End If
                If Team2Score = 45 And Team1Score < 45 Then
                    RandomWinner = 0
                End If
                Console.WriteLine("The round has begun...")
                System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
                If RandomWinner > 50 Then
                    Team1Score = Team1Score + 1
                    Console.WriteLine("{0} has taken the round.", Team1)
                    Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
                Else
                    Team2Score = Team2Score + 1
                    Console.WriteLine("{0} has taken the round.", Team2)
                    Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
                End If
            Loop

            System.Threading.Thread.Sleep(Rand.Next(500, 1501))
            DetermWin()
        End If


        'If OvertimeChance > 75 Then
        '    If OvertimeFormat = "1" Then
        '        Dim OvertimeWinsChance As Integer = Rand.Next(0, 101)
        '        Dim OvertimeMaxRounds = 19
        '        Dim OvertimeMinRounds = 15
        '        If OvertimeWinsChance <= 80 Then
        '            OvertimeMaxRounds = 19
        '            OvertimeMinRounds = 15
        '        End If
        '        If OvertimeWinsChance > 80 And OvertimeWinsChance <= 90 Then
        '            OvertimeMaxRounds = 22
        '            OvertimeMinRounds = 18
        '        End If
        '        If OvertimeWinsChance > 90 And OvertimeWinsChance <= 95 Then
        '            OvertimeMaxRounds = 25
        '            OvertimeMinRounds = 21
        '        End If
        '        If OvertimeWinsChance > 95 And OvertimeWinsChance <= 100 Then
        '            OvertimeMaxRounds = 28
        '            OvertimeMinRounds = 24
        '        End If
        '        While Team1Score <> OvertimeMaxRounds Or Team2Score <> OvertimeMaxRounds
        '            Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
        '            Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
        '        End While
        '        If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds Then
        '            If RandomWinner > 50 Then
        '                Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
        '                Team2Score = OvertimeMaxRounds
        '            Else
        '                Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
        '                Team1Score = OvertimeMaxRounds
        '            End If
        '        End If
        '        If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds - 1 Then
        '            Team2Score = OvertimeMaxRounds - 2
        '        End If
        '        If Team1Score = OvertimeMaxRounds - 1 And Team2Score = OvertimeMaxRounds Then
        '            Team1Score = OvertimeMaxRounds - 2
        '        End If
        '    Else
        '        Dim OvertimeWinsChance As Integer = Rand.Next(0, 101)
        '        Dim OvertimeMaxRounds = 21
        '        Dim OvertimeMinRounds = 15
        '        If OvertimeWinsChance <= 80 Then
        '            OvertimeMaxRounds = 21
        '            OvertimeMinRounds = 15
        '        End If
        '        If OvertimeWinsChance > 80 And OvertimeWinsChance <= 90 Then
        '            OvertimeMaxRounds = 26
        '            OvertimeMinRounds = 20
        '        End If
        '        If OvertimeWinsChance > 90 And OvertimeWinsChance <= 95 Then
        '            OvertimeMaxRounds = 31
        '            OvertimeMinRounds = 25
        '        End If
        '        If OvertimeWinsChance > 95 And OvertimeWinsChance <= 100 Then
        '            OvertimeMaxRounds = 36
        '            OvertimeMinRounds = 30
        '        End If
        '        While Team1Score <> OvertimeMaxRounds Or Team2Score <> OvertimeMaxRounds
        '            Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
        '            Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds + 1)
        '        End While
        '        If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds Then
        '            If RandomWinner > 50 Then
        '                Team1Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
        '                Team2Score = OvertimeMaxRounds
        '            Else
        '                Team2Score = Rand.Next(OvertimeMinRounds, OvertimeMaxRounds - 1)
        '                Team1Score = OvertimeMaxRounds
        '            End If
        '        End If
        '        If Team1Score = OvertimeMaxRounds And Team2Score = OvertimeMaxRounds - 1 Then
        '            Team2Score = OvertimeMaxRounds - 2
        '        End If
        '        If Team1Score = OvertimeMaxRounds - 1 And Team2Score = OvertimeMaxRounds Then
        '            Team1Score = OvertimeMaxRounds - 2
        '        End If
        '    End If
        'End If
        'Console.ReadLine()
    End Sub
    Sub OvertimeFalse()
        Console.Clear()
        'While Team1Score <> 16 Or Team2Score <> 16
        '    Team1Score = Rand.Next(0, 17)
        '    Team2Score = Rand.Next(0, 17)
        '    If Team1Score = 15 And Team2Score = 15 Then
        '        Exit While
        '    End If
        'End While
        'If Team1Score = 16 And Team2Score = 16 Then
        '    If RandomWinner > 50 Then
        '        Team1Score = Rand.Next(0, 15)
        '    Else
        '        Team2Score = Rand.Next(0, 15)
        '    End If
        'End If
        'If Team1Score = 16 And Team2Score = 15 Then
        '    Team2Score = 14
        'End If
        'If Team1Score = 15 And Team2Score = 16 Then
        '    Team1Score = 14
        'End If
        'Dim Winner As String
        'If Team1Score > Team2Score Then
        '    Winner = Team1
        'Else
        '    Winner = Team2
        'End If
        'If Team1Score = Team2Score Then
        '    Winner = "Draw"
        'End If
        'If Winner <> "Draw" Then
        '    Console.WriteLine("The winner is {0}.", Winner)
        'Else
        '    Console.WriteLine("The game ended as a draw.")
        'End If
        'If Winner = Team1 Then
        '    Console.WriteLine("The score ended as {0} - {1}.", Team1Score, Team2Score)
        'Else
        '    Console.WriteLine("The score ended as {0} - {1}.", Team2Score, Team1Score)
        'End If
        'Console.ReadLine()


        'Start Rounds
        For i = 1 To 30
            'If there is a winner, quit
            If Team1Score = 16 Or Team2Score = 16 Then
                DetermWin()
            End If
            'Wait between round beginnings and endings
            If i > 1 Then
                Console.WriteLine("")
                System.Threading.Thread.Sleep(Rand.Next(500, 2001))
            End If
            'Halftime logic
            If i = 16 Then
                Dim Timer As Integer = 5
                System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                Console.Clear()
                Console.WriteLine("Breaking for half time...")
                System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                For HalfTimeCount = 1 To 5
                    Console.WriteLine("Resuming in {0}...", Timer)
                    System.Threading.Thread.Sleep(1000)
                    Timer = Timer - 1
                    If HalfTimeCount = 5 Then
                        Console.Clear()
                    End If
                Next
            End If
            'Begin round + round mechanics
            RandomWinner = Rand.Next(0, 101)
            Console.WriteLine("The round has begun...")
            System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
            If RandomWinner > 50 Then
                Team1Score = Team1Score + 1
                Console.WriteLine("{0} has taken the round.", Team1)
                Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
            Else
                Team2Score = Team2Score + 1
                Console.WriteLine("{0} has taken the round.", Team2)
                Console.WriteLine("The score is now {0}: {1} - {2}: {3}", Team1, Team1Score, Team2, Team2Score)
            End If
        Next
        System.Threading.Thread.Sleep(Rand.Next(500, 1501))
        DetermWin()
    End Sub
    Sub DetermWin()
        Console.Clear()
        Dim Winner As String = ""
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
        Main()
    End Sub
End Module
