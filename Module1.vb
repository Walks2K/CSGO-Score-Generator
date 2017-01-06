Module Module1
    Public Team1 As String
    Public Team2 As String
    Public Team1Score As Integer
    Public Team2Score As Integer
    Public Rand As New Random
    Public RandomWinner As Integer = Rand.Next(0, 101)
    Public HalfTime As Boolean = True
    Public KnifeRound As Boolean = True
    Public MapPool(6) As String
    Public ScrambledMapPool(6) As String
    Public SideCT As String
    Public SideT As String
    Public SideCTPercent As Integer
    Public SideTPercent As Integer
    Public Team1Side As String
    Public Team2Side As String
    Public BestOf As Integer
    Public Team1Maps As Integer
    Public Team2Maps As Integer
    Public Map1Score As String
    Public Map2Score As String
    Public Map3Score As String
    Public Map1Winner As String
    Public Map2Winner As String
    Public Map3Winner As String
    Public Map1Loser As String
    Public Map2Loser As String
    Public Map3Loser As String


    Public Sub Main()
        Console.Clear()
        RandomWinner = Rand.Next(0, 101)
        Team1Score = 0
        Team2Score = 0
        Team1 = ""
        Team2 = ""
        Team1Maps = 0
        Team2Maps = 0
        Map1Score = ""
        Map2Score = ""
        Map3Score = ""
        Map1Winner = ""
        Map2Winner = ""
        Map3Winner = ""
        Map1Loser = ""
        Map2Loser = ""
        Map3Loser = ""
        MapPool(0) = "Cache"
        MapPool(1) = "Cobblestone"
        MapPool(2) = "Dust 2"
        MapPool(3) = "Mirage"
        MapPool(4) = "Nuke"
        MapPool(5) = "Overpass"
        MapPool(6) = "Train"
        Array.Clear(ScrambledMapPool, 0, ScrambledMapPool.Length)
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
        Console.WriteLine("1. Half Time: {0}", HalfTime)
        Console.WriteLine("2. Knife Round: {0}", KnifeRound)
        Console.WriteLine("9. Home")

        Dim UserChoice As String = Console.ReadLine
        Select Case UserChoice
            Case 1
                If HalfTime = True Then
                    HalfTime = False
                Else
                    HalfTime = True
                End If
                Configure()
            Case 2
                If KnifeRound = True Then
                    KnifeRound = False
                Else
                    KnifeRound = True
                End If
                Configure()
            Case 9
                Main()
            Case Else
                Configure()
        End Select
    End Sub
    Sub GameSetup()
        Console.Clear()
        Console.WriteLine("Is overtime possible in the game you want to predict? Y/N")
        Dim Overtime As String = Console.ReadLine
        While Overtime <> "Y" And Overtime <> "N"
            Console.Clear()
            Console.WriteLine("That is not valid, please try again now.")
            Console.WriteLine("Is overtime possible in the game you want to predict? Y/N")
            Overtime = Console.ReadLine
        End While
        Console.Clear()
        Console.WriteLine("Please enter the name of the first team now.")
        Team1 = Console.ReadLine
        Console.WriteLine("Please enter the name of the second team now.")
        Team2 = Console.ReadLine
        Console.Clear()
        Console.WriteLine("Do you want a BO1 or BO3?")
        Console.WriteLine("1. BO1")
        Console.WriteLine("2. BO3")
        BestOf = Console.ReadLine
        While BestOf <> "1" And BestOf <> "2"
            Console.WriteLine("That is not valid, please try again now.")
            Console.WriteLine("Do you want a BO1 or BO3?")
            Console.WriteLine("1. BO1")
            Console.WriteLine("2. BO3")
            BestOf = Console.ReadLine
        End While
        If BestOf = 1 Then
            BestOf = 0
        Else
            BestOf = 2
        End If
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

        For MapsPlayed As Integer = 0 To BestOf
            Team1Score = 0
            Team2Score = 0
            Console.Clear()
            Console.WriteLine("The map is: {0}", ScrambledMapPool(MapsPlayed))
            If BestOf > 0 Then
                Console.WriteLine("Map {0} / 3", MapsPlayed + 1)
                If MapsPlayed = 0 Then
                    Console.WriteLine("Map 1: {0}, Map 2: {1}, Map 3: {2}", ScrambledMapPool(0), ScrambledMapPool(1), ScrambledMapPool(2))
                End If
                If MapsPlayed = 1 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("Map 1: {0}, ", ScrambledMapPool(0))
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.Write("Map 2: {0}, Map 3: {1}", ScrambledMapPool(1), ScrambledMapPool(2))
                End If
                If MapsPlayed = 2 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("Map 1: {0}, Map 2: {1}, ", ScrambledMapPool(0), ScrambledMapPool(1))
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.Write("Map 3: {0}", ScrambledMapPool(2))
                End If
                Console.WriteLine("")
                Console.WriteLine("Series Score: {0}: {1} - {2}: {3}", Team1, Team1Maps, Team2, Team2Maps)
            End If
            If ScrambledMapPool(0) = "Cache" Then
                SideCTPercent = 54
                SideTPercent = 46
            End If

            If ScrambledMapPool(0) = "Dust 2" Then
                SideCTPercent = 49
                SideTPercent = 51
            End If

            If ScrambledMapPool(0) = "Cobblestone" Then
                SideCTPercent = 52
                SideTPercent = 48
            End If

            If ScrambledMapPool(0) = "Mirage" Then
                SideCTPercent = 54
                SideTPercent = 46
            End If

            If ScrambledMapPool(0) = "Nuke" Then
                SideCTPercent = 60
                SideTPercent = 40
            End If

            If ScrambledMapPool(0) = "Overpass" Then
                SideCTPercent = 57
                SideTPercent = 43
            End If

            If ScrambledMapPool(0) = "Train" Then
                SideCTPercent = 70
                SideTPercent = 30
            End If

            If KnifeRound = True Then
                RandomWinner = Rand.Next(0, 101)
                If RandomWinner >= 50 Then
                    Console.WriteLine("{0} have won the knife round.", Team1)
                    If SideCTPercent > SideTPercent Then
                        Console.WriteLine("{0} have went with the CT side.", Team1)
                        SideCT = Team1
                        SideT = Team2
                        Team1Side = "CT"
                        Team2Side = "T"
                    Else
                        Console.WriteLine("{0} have went with the T side.", Team1)
                        SideT = Team1
                        SideCT = Team2
                        Team2Side = "CT"
                        Team1Side = "T"
                    End If
                Else
                    Console.WriteLine("{0} have won the knife round.", Team2)
                    If SideCTPercent > SideTPercent Then
                        Console.WriteLine("{0} have went with the CT side.", Team2)
                        SideCT = Team2
                        SideT = Team1
                        Team2Side = "CT"
                        Team1Side = "T"
                    Else
                        Console.WriteLine("{0} have went with the T side.", Team2)
                        SideT = Team2
                        SideCT = Team1
                        Team1Side = "CT"
                        Team2Side = "T"
                    End If
                    SideCT = Team2
                    SideT = Team1
                End If
            End If

            System.Threading.Thread.Sleep(3000)
            Dim LO3 As Integer = 3
            Dim Countdown
            For Countdown = 1 To 3
                Console.WriteLine("Going live in {0}...", LO3)
                LO3 = LO3 - 1
                System.Threading.Thread.Sleep(1000)
            Next

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
                    HalfTimes(WinningScoresLoop) = 28 + (3 * WinningScoresLoop)
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
                    If HalfTimes.Contains(i) Then
                        If SideCT = Team1 And SideT = Team2 Then
                            SideCT = Team2
                            SideT = Team1
                            Team1Side = "T"
                            Team2Side = "CT"
                        Else
                            SideCT = Team1
                            SideT = Team2
                            Team1Side = "CT"
                            Team2Side = "T"
                        End If
                    End If
                    If HalfTimes.Contains(i) And HalfTime = True Then
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
                        Console.WriteLine("The score is currently ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    End If
                    'Begin round + round mechanics
                    RandomWinner = Rand.Next(0, 101)
                    If Team1Score = 45 And Team2Score < 45 Then
                        RandomWinner = 100
                    End If
                    If Team2Score = 45 And Team1Score < 45 Then
                        RandomWinner = 0
                    End If
                    Console.WriteLine("Round {0} has begun...", i)
                    System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
                    If RandomWinner >= SideTPercent Then
                        If SideCT = Team1 Then
                            Team1Score = Team1Score + 1
                            Console.WriteLine("{0} has taken the round.", Team1)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        Else
                            Team2Score = Team2Score + 1
                            Console.WriteLine("{0} has taken the round.", Team2)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        End If
                    Else
                        If SideT = Team1 Then
                            Team1Score = Team1Score + 1
                            Console.WriteLine("{0} has taken the round.", Team1)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        Else
                            Team2Score = Team2Score + 1
                            Console.WriteLine("{0} has taken the round.", Team2)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        End If
                    End If
                Loop
                If BestOf = 0 Then
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    DetermWin()
                End If
                System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                If Team1Score > Team2Score Then
                    Team1Maps = Team1Maps + 1
                    Console.WriteLine("{0} have took Map {1}", Team1, ScrambledMapPool(MapsPlayed))
                Else
                    Team2Maps = Team2Maps + 1
                    Console.WriteLine("{0} have took Map {1}", Team2, ScrambledMapPool(MapsPlayed))
                End If

                If MapsPlayed = 0 And Team1Score > Team2Score Then
                    Map1Winner = Team1
                    Map1Loser = Team2
                    Map1Score = String.Join(" - ", Team1Score, Team2Score)
                End If

                If MapsPlayed = 0 And Team1Score < Team2Score Then
                    Map1Winner = Team2
                    Map1Loser = Team1
                    Map1Score = String.Join(" - ", Team2Score, Team1Score)
                End If

                If MapsPlayed = 1 And Team1Score > Team2Score Then
                    Map2Winner = Team1
                    Map2Loser = Team2
                    Map2Score = String.Join(" - ", Team1Score, Team2Score)
                End If

                If MapsPlayed = 1 And Team1Score < Team2Score Then
                    Map2Winner = Team2
                    Map2Loser = Team1
                    Map2Score = String.Join(" - ", Team2Score, Team1Score)
                End If

                If MapsPlayed = 2 And Team1Score > Team2Score Then
                    Map3Winner = Team1
                    Map3Loser = Team2
                    Map3Score = String.Join(" - ", Team1Score, Team2Score)
                End If

                If MapsPlayed = 2 And Team1Score < Team2Score Then
                    Map3Winner = Team2
                    Map3Loser = Team1
                    Map3Score = String.Join(" - ", Team2Score, Team1Score)
                End If

                If Team1Maps = 2 Then
                    System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                    Exit For
                End If
                If Team2Maps = 2 Then
                    System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                    Exit For
                End If
                System.Threading.Thread.Sleep(Rand.Next(3000, 6001))
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
                    HalfTimes(WinningScoresLoop) = 26 + (5 * WinningScoresLoop)
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
                    If HalfTimes.Contains(i) Then
                        If SideCT = Team1 And SideT = Team2 Then
                            SideCT = Team2
                            SideT = Team1
                            Team1Side = "T"
                            Team2Side = "CT"
                        Else
                            SideCT = Team1
                            SideT = Team2
                            Team1Side = "CT"
                            Team2Side = "T"
                        End If
                    End If
                    If HalfTimes.Contains(i) And HalfTime = True Then
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
                        Console.WriteLine("The score is currently ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    End If
                    'Begin round + round mechanics
                    RandomWinner = Rand.Next(0, 101)
                    If Team1Score = 45 And Team2Score < 45 Then
                        RandomWinner = 100
                    End If
                    If Team2Score = 45 And Team1Score < 45 Then
                        RandomWinner = 0
                    End If
                    Console.WriteLine("Round {0} has begun...", i)
                    System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
                    If RandomWinner >= SideTPercent Then
                        If SideCT = Team1 Then
                            Team1Score = Team1Score + 1
                            Console.WriteLine("{0} has taken the round.", Team1)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        Else
                            Team2Score = Team2Score + 1
                            Console.WriteLine("{0} has taken the round.", Team2)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        End If
                    Else
                        If SideT = Team1 Then
                            Team1Score = Team1Score + 1
                            Console.WriteLine("{0} has taken the round.", Team1)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        Else
                            Team2Score = Team2Score + 1
                            Console.WriteLine("{0} has taken the round.", Team2)
                            Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                        End If
                    End If
                Loop
                If BestOf = 0 Then
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                    DetermWin()
                End If
                System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                If Team1Score > Team2Score Then
                    Team1Maps = Team1Maps + 1
                    Console.WriteLine("{0} have took Map {1}", Team1, ScrambledMapPool(MapsPlayed))
                Else
                    Team2Maps = Team2Maps + 1
                    Console.WriteLine("{0} have took Map {1}", Team2, ScrambledMapPool(MapsPlayed))
                End If
                If Team1Maps = 2 Then
                    System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                    Exit For
                End If
                If Team2Maps = 2 Then
                    System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                    Exit For
                End If
                System.Threading.Thread.Sleep(Rand.Next(3000, 6001))
            End If
        Next
        System.Threading.Thread.Sleep(Rand.Next(500, 1501))
        Console.Clear()
        Dim Winner As String = ""
        If Team1Maps > Team2Maps Then
            Winner = Team1
        Else
            Winner = Team2
        End If
        If Winner <> "Draw" Then
            Console.WriteLine("The winner is {0}.", Winner)
        End If
        If Winner = Team1 Then
            Console.WriteLine("The series score ended as {0} - {1}.", Team1Maps, Team2Maps)
        Else
            Console.WriteLine("The series score ended as {0} - {1}.", Team2Maps, Team1Maps)
        End If
        Console.WriteLine("Map Scores:")
        Console.WriteLine("Map 1: {0} {1} {2}", Map1Winner, Map1Score, Map1Loser)
        Console.WriteLine("Map 2: {0} {1} {2}", Map2Winner, Map2Score, Map2Loser)
        If Team1Maps = 2 And Team2Maps = 1 Then
        ElseIf Team1Maps = 1 And Team2Maps = 2 Then
            Console.WriteLine("Map 3: {0} {1} {2}", Map3Winner, Map3Score, Map3Loser)
        End If
        Console.ReadLine()
        Main()
    End Sub
    Sub OvertimeFalse()
        For MapsPlayed As Integer = 0 To BestOf
            Team1Score = 0
            Team2Score = 0
            Console.Clear()
            Console.WriteLine("The map is: {0}", ScrambledMapPool(MapsPlayed))
            If BestOf > 0 Then
                Console.WriteLine("Map {0} / 3", MapsPlayed + 1)
                If MapsPlayed = 0 Then
                    Console.WriteLine("Map 1: {0}, Map 2: {1}, Map 3: {2}", ScrambledMapPool(0), ScrambledMapPool(1), ScrambledMapPool(2))
                End If
                If MapsPlayed = 1 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("Map 1: {0}, ", ScrambledMapPool(0))
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.Write("Map 2: {0}, Map 3: {1}", ScrambledMapPool(1), ScrambledMapPool(2))
                End If
                If MapsPlayed = 2 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("Map 1: {0}, Map 2: {1}, ", ScrambledMapPool(0), ScrambledMapPool(1))
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.Write("Map 3: {0}", ScrambledMapPool(2))
                End If
                Console.WriteLine("")
                Console.WriteLine("Series Score: {0}: {1} - {2}: {3}", Team1, Team1Maps, Team2, Team2Maps)
            End If
            If ScrambledMapPool(0) = "Cache" Then
                SideCTPercent = 54
                SideTPercent = 46
            End If

            If ScrambledMapPool(0) = "Dust 2" Then
                SideCTPercent = 49
                SideTPercent = 51
            End If

            If ScrambledMapPool(0) = "Cobblestone" Then
                SideCTPercent = 52
                SideTPercent = 48
            End If

            If ScrambledMapPool(0) = "Mirage" Then
                SideCTPercent = 54
                SideTPercent = 46
            End If

            If ScrambledMapPool(0) = "Nuke" Then
                SideCTPercent = 60
                SideTPercent = 40
            End If

            If ScrambledMapPool(0) = "Overpass" Then
                SideCTPercent = 57
                SideTPercent = 43
            End If

            If ScrambledMapPool(0) = "Train" Then
                SideCTPercent = 70
                SideTPercent = 30
            End If

            If KnifeRound = True Then
                RandomWinner = Rand.Next(0, 101)
                If RandomWinner >= 50 Then
                    Console.WriteLine("{0} have won the knife round.", Team1)
                    If SideCTPercent > SideTPercent Then
                        Console.WriteLine("{0} have went with the CT side.", Team1)
                        SideCT = Team1
                        SideT = Team2
                        Team1Side = "CT"
                        Team2Side = "T"
                    Else
                        Console.WriteLine("{0} have went with the T side.", Team1)
                        SideT = Team1
                        SideCT = Team2
                        Team2Side = "CT"
                        Team1Side = "T"
                    End If
                Else
                    Console.WriteLine("{0} have won the knife round.", Team2)
                    If SideCTPercent > SideTPercent Then
                        Console.WriteLine("{0} have went with the CT side.", Team2)
                        SideCT = Team2
                        SideT = Team1
                        Team2Side = "CT"
                        Team1Side = "T"
                    Else
                        Console.WriteLine("{0} have went with the T side.", Team2)
                        SideT = Team2
                        SideCT = Team1
                        Team1Side = "CT"
                        Team2Side = "T"
                    End If
                    SideCT = Team2
                    SideT = Team1
                End If
            End If

            System.Threading.Thread.Sleep(3000)
            Dim LO3 As Integer = 3
            Dim Countdown
            For Countdown = 1 To 3
                Console.WriteLine("Going live in {0}...", LO3)
                LO3 = LO3 - 1
                System.Threading.Thread.Sleep(1000)
            Next

            Console.Clear()


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
                HalfTimes(WinningScoresLoop) = 28 + (3 * WinningScoresLoop)
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
                If HalfTimes.Contains(i) Then
                    If SideCT = Team1 And SideT = Team2 Then
                        SideCT = Team2
                        SideT = Team1
                        Team1Side = "T"
                        Team2Side = "CT"
                    Else
                        SideCT = Team1
                        SideT = Team2
                        Team1Side = "CT"
                        Team2Side = "T"
                    End If
                End If
                If HalfTimes.Contains(i) And HalfTime = True Then
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
                    Console.WriteLine("The score is currently ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                    System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                End If
                'Begin round + round mechanics
                RandomWinner = Rand.Next(0, 101)
                If Team1Score = 15 And Team2Score = 15 Then
                    Exit For
                End If
                Console.WriteLine("Round {0} has begun...", i)
                System.Threading.Thread.Sleep(Rand.Next(1000, 2001))
                If RandomWinner >= SideTPercent Then
                    If SideCT = Team1 Then
                        Team1Score = Team1Score + 1
                        Console.WriteLine("{0} has taken the round.", Team1)
                        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                    Else
                        Team2Score = Team2Score + 1
                        Console.WriteLine("{0} has taken the round.", Team2)
                        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                    End If
                Else
                    If SideT = Team1 Then
                        Team1Score = Team1Score + 1
                        Console.WriteLine("{0} has taken the round.", Team1)
                        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                    Else
                        Team2Score = Team2Score + 1
                        Console.WriteLine("{0} has taken the round.", Team2)
                        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
                    End If
                End If
            Loop

            If BestOf = 0 Then
                System.Threading.Thread.Sleep(Rand.Next(500, 1501))
                DetermWin()
            End If

            System.Threading.Thread.Sleep(Rand.Next(1500, 3001))

            If Team1Score > Team2Score Then
                Team1Maps = Team1Maps + 1
                Console.WriteLine("{0} have took Map {1}", Team1, ScrambledMapPool(MapsPlayed))
            End If

            If Team2Score > Team1Score Then
                Team2Maps = Team2Maps + 1
                Console.WriteLine("{0} have took Map {1}", Team2, ScrambledMapPool(MapsPlayed))
            End If

            If Team1Maps = 2 Then
                System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                Exit For
            End If

            If Team2Maps = 2 Then
                System.Threading.Thread.Sleep(Rand.Next(1500, 3001))
                Exit For
            End If
            System.Threading.Thread.Sleep(Rand.Next(3000, 6001))
        Next
        System.Threading.Thread.Sleep(Rand.Next(500, 1501))
        Console.Clear()
        Dim Winner As String = ""
        If Team1Maps > Team2Maps Then
            Winner = Team1
        Else
            Winner = Team2
        End If
        If Winner <> "Draw" Then
            Console.WriteLine("The winner is {0}.", Winner)
        End If
        If Winner = Team1 Then
            Console.WriteLine("The score ended as {0} - {1}.", Team1Maps, Team2Maps)
        Else
            Console.WriteLine("The score ended as {0} - {1}.", Team2Maps, Team1Maps)
        End If
        Console.ReadLine()
        Main()
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
