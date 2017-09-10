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
	Public BestOf As Double
	Public BestOfWin As Double
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
	Public MapWinners(6) As String
	Public MapLosers(6) As String
	Public MapScores(6) As String
	Public MapHalftimeScores(6, 9) As String
	Public ChooseMaps As Boolean = False
	Public Players(9) As String
	Public PlayerKills(9) As Integer
	Public PlayerDeaths(9) As Integer
	Public PlayerKillsTotal(6, 9) As Integer
	Public PlayerDeathsTotal(6, 9) As Integer
	Public MapsPlayedCounter As Integer
	Public MapsPlayedList(6) As String
	Public G2Lineup() As String = {"shox", "apEX", "kennyS", "NBK-", "bodyy"}
	Public NorthLineup() As String = {"MSL", "K0NFIG", "aizy", "valde", "cajub"}
	Public ValidusLineup() As String = {"chewy", "fadeless", "smokey2k", "Synisty", "murf"}
	Public fnaticLineup() As String = {"flusha", "JW", "KRIMZ", "Golden", "Lekr0"}
	Public SKLineup() As String = {"fer", "coldzera", "TACO", "felps", "FalleN"}
	Public FaZeLineup() As String = {"karrigan", "olofmeister", "Guardian", "NiKo", "rain"}
	Public AstralisLineup() As String = {"Xyp9x", "dupreeh", "gla1ve", "device", "Kjaerbye"}
	Public GambitLineup() As String = {"AdreN", "Dosia", "mou", "HObbit", "fitch"}
	Public NaViLineup() As String = {"Edward", "Zeus", "seized", "flamie", "s1mple"}
	Public ImmortalsLineup() As String = {"kNgV-", "steel", "HEN1", "LUCAS1", "boltz"}
	Public VirtusProLineup() As String = {"TaZ", "NEO", "pashaBiceps", "Snax", "byali"}
	Public Cloud9Lineup() As String = {"Skadoodle", "RUSH", "tarik", "autimatic", "Stewie2K"}
	Public EnVyUsLineup() As String = {"SIXER", "RpK", "ScreaM", "Happy", "xms"}
	Public NiPLineup() As String = {"f0rest", "GeT_RiGhT", "Xizt", "draken", "REZ"}
	Public BIGLineup() As String = {"gob b", "LEGIJA", "tabseN", "keev", "nex"}
	Public mousesportslineup() As String = {"oskar", "chrisJ", "suNny", "STYKO", "ropz"}
	Public SlowDown As Boolean = True

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
		For i = 0 To 6
			MapWinners(i) = ""
			MapLosers(i) = ""
			MapScores(i) = ""
			For j = 0 To 9
				MapHalftimeScores(i, j) = ""
			Next
		Next
		MapPool(0) = "Cache"
		MapPool(1) = "Cobblestone"
		MapPool(2) = "Inferno"
		MapPool(3) = "Mirage"
		MapPool(4) = "Nuke"
		MapPool(5) = "Overpass"
		MapPool(6) = "Train"
		If ChooseMaps = False Then
			Array.Clear(ScrambledMapPool, 0, ScrambledMapPool.Length)
			For i = 0 To 6
				Dim RandomMap As Integer
				RandomMap = Rand.Next(0, 7)
				While ScrambledMapPool.Contains(MapPool(RandomMap))
					RandomMap = Rand.Next(0, 7)
				End While
				ScrambledMapPool(i) = MapPool(RandomMap)
			Next
		End If

		Console.WriteLine("Welcome to the CSGO score prediction maker!" & vbCrLf & "What would you like to do?")
		Console.WriteLine("1. Setup Game")
		Console.WriteLine("2. Configure Options")
		Console.WriteLine("3. Select Map Order")
		Console.WriteLine("4. Manual Maps?: {0}", ChooseMaps)
		Dim UserChoice As String = Console.ReadLine
		Select Case UserChoice
			Case 1
				GameSetup()
			Case 2
				Configure()
			Case 3
				Maps()
			Case 4
				If ChooseMaps = True Then
					ChooseMaps = False
				Else
					ChooseMaps = True
				End If
				Main()
			Case Else
				Main()
		End Select
	End Sub
	Sub Configure()
		Console.Clear()
		Console.WriteLine("1. Half Time: {0}", HalfTime)
		Console.WriteLine("2. Knife Round: {0}", KnifeRound)
		Console.WriteLine("3. Slow Down: {0}", SlowDown)
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
			Case 3
				If SlowDown = True Then
					SlowDown = False
				Else
					SlowDown = True
				End If
				Configure()
			Case 9
				Main()
			Case Else
				Configure()
		End Select
	End Sub
	Sub GameSetup()
		For i = 0 To 6
			For j = 0 To 9
				PlayerKillsTotal(i, j) = 0
				PlayerDeathsTotal(i, j) = 0
				PlayerKills(j) = 0
				PlayerDeaths(j) = 0
			Next
		Next
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

		If Overtime = "N" Then
			Console.WriteLine("This is deprecated, returning to menu in...")
			For i = 3 To 1 Step -1
				Console.WriteLine("{0}...", i)
				Threading.Thread.Sleep(1000)
			Next
			Main()
		End If

		Console.WriteLine("Please enter the name of the first team now.")
		Team1 = Console.ReadLine

		If Team1 = "G2" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = G2Lineup(PlayerNames)
			Next
		ElseIf Team1 = "North" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = NorthLineup(PlayerNames)
			Next
		ElseIf Team1 = "Validus.GG" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = ValidusLineup(PlayerNames)
			Next
		ElseIf Team1 = "fnatic" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = fnaticLineup(PlayerNames)
			Next
		ElseIf Team1 = "SK" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = SKLineup(PlayerNames)
			Next
		ElseIf Team1 = "FaZe" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = FaZeLineup(PlayerNames)
			Next
		ElseIf Team1 = "Astralis" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = AstralisLineup(PlayerNames)
			Next
		ElseIf Team1 = "Gambit" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = GambitLineup(PlayerNames)
			Next
		ElseIf Team1 = "Natus Vincere" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = NaViLineup(PlayerNames)
			Next
		ElseIf Team1 = "Immortals" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = ImmortalsLineup(PlayerNames)
			Next
		ElseIf Team1 = "Cloud9" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = Cloud9Lineup(PlayerNames)
			Next
		ElseIf Team1 = "EnVyUs" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = EnVyUsLineup(PlayerNames)
			Next
		ElseIf Team1 = "NiP" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = NiPLineup(PlayerNames)
			Next
		ElseIf Team1 = "BIG" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = BIGLineup(PlayerNames)
			Next
		ElseIf Team1 = "mousesports" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = mousesportslineup(PlayerNames)
			Next
		ElseIf Team1 = "Virtus.Pro" Then
			For PlayerNames = 0 To 4
				Players(PlayerNames) = VirtusProLineup(PlayerNames)
			Next
		Else
			For i = 0 To 4
				Console.WriteLine("Enter the name of player {0} now.", i + 1)
				Players(i) = Console.ReadLine
			Next
		End If
		'Team 1 Players
		Console.Clear()

		Console.WriteLine("Please enter the name of the second team now.")
		Team2 = Console.ReadLine

		If Team2 = "G2" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = G2Lineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "North" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = NorthLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Validus.GG" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = ValidusLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "fnatic" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = fnaticLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "SK" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = SKLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "FaZe" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = FaZeLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Astralis" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = AstralisLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Gambit" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = GambitLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Natus Vincere" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = NaViLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Immortals" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = ImmortalsLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Cloud9" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = Cloud9Lineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "EnVyUs" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = EnVyUsLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "NiP" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = NiPLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "BIG" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = BIGLineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "mousesports" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = mousesportslineup(PlayerNames - 5)
			Next
		ElseIf Team2 = "Virtus.Pro" Then
			For PlayerNames = 5 To 9
				Players(PlayerNames) = VirtusProLineup(PlayerNames - 5)
			Next
		Else
			For i = 5 To 9
				Console.WriteLine("Enter the name of player {0} now.", i + 1)
				Players(i) = Console.ReadLine
			Next
		End If

		Console.Clear()
		Console.WriteLine("Enter the amount of maps required to win now. (1 = BO1, 3 = BO3 etc.)")
		BestOf = Console.ReadLine
		While BestOf < "1" And BestOf > "7"
			Console.WriteLine("That is not valid, please try again now.")
			BestOf = Console.ReadLine
		End While

		BestOfWin = BestOf / 2

		If Not BestOfWin = Int(BestOfWin) Then
			BestOfWin = BestOfWin + 0.5
		End If


		If Overtime = "Y" Then
			OvertimeTrue()
		End If

		If Overtime = "N" Then
			OvertimeFalse()
		End If
	End Sub
	Sub OvertimeTrue()
		MapPool(0) = "Cache"
		MapPool(1) = "Cobblestone"
		MapPool(2) = "Inferno"
		MapPool(3) = "Mirage"
		MapPool(4) = "Nuke"
		MapPool(5) = "Overpass"
		MapPool(6) = "Train"
		If ChooseMaps = False Then
			Array.Clear(ScrambledMapPool, 0, ScrambledMapPool.Length)
			For i = 0 To 6
				Dim RandomMap As Integer
				RandomMap = Rand.Next(0, 7)
				While ScrambledMapPool.Contains(MapPool(RandomMap))
					RandomMap = Rand.Next(0, 7)
				End While
				ScrambledMapPool(i) = MapPool(RandomMap)
			Next
		End If
		Dim StartingSide As String = "0"
		Console.Clear()
		Console.WriteLine("What format will the overtime be?" & vbCrLf & "1. MR6" & vbCrLf & "2. MR10")
		Dim OvertimeFormat As String = Console.ReadLine
		While OvertimeFormat <> "1" And OvertimeFormat <> "2"
			Console.WriteLine("That is not valid, please try again now.")
			OvertimeFormat = Console.ReadLine
		End While

		For MapsFor As Integer = 0 To 6
			MapsPlayedList(MapsFor) = ScrambledMapPool(MapsFor)
		Next

		For MapsPlayed As Integer = 0 To BestOf - 1
			Team1Score = 0
			Team2Score = 0
			Console.Clear()
			Console.WriteLine("The map is: {0}", ScrambledMapPool(MapsPlayed))
			If BestOf > 0 Then
				Console.WriteLine("Map {0} / {1}", MapsPlayed + 1, BestOf)
				For WriteMapsPlayed As Integer = 0 To MapsPlayed - 1
					Console.ForegroundColor = ConsoleColor.Red
					Console.Write(vbCrLf + "Map {0}: {1}: {2} {3} {4}", WriteMapsPlayed + 1, ScrambledMapPool(WriteMapsPlayed), MapWinners(WriteMapsPlayed), MapScores(WriteMapsPlayed), MapLosers(WriteMapsPlayed))
					For HalftimePrint As Integer = 0 To 9
						If MapHalftimeScores(WriteMapsPlayed, HalftimePrint) <> "" Then
							Console.Write(" / {0} {1} {2}", Team1, MapHalftimeScores(WriteMapsPlayed, HalftimePrint), Team2)
						End If
					Next
				Next
				For BestOfWrite As Integer = MapsPlayed To BestOf - 1
					Console.ForegroundColor = ConsoleColor.Gray
					Console.Write(vbCrLf + "Map {0}: {1}", BestOfWrite + 1, ScrambledMapPool(BestOfWrite))
				Next

				'If MapsPlayed = 0 Then
				'	Console.WriteLine("Map 1: {0}, Map 2: {1}, Map 3: {2}", ScrambledMapPool(0), ScrambledMapPool(1), ScrambledMapPool(2))
				'End If
				'If MapsPlayed = 1 Then
				'	Console.ForegroundColor = ConsoleColor.Red
				'	Console.Write("Map 1: {0}, ", ScrambledMapPool(0))
				'	Console.ForegroundColor = ConsoleColor.Gray
				'	Console.Write("Map 2: {0}, Map 3: {1}", ScrambledMapPool(1), ScrambledMapPool(2))
				'End If
				'If MapsPlayed = 2 Then
				'	Console.ForegroundColor = ConsoleColor.Red
				'	Console.Write("Map 1: {0}, Map 2: {1}, ", ScrambledMapPool(0), ScrambledMapPool(1))
				'	Console.ForegroundColor = ConsoleColor.Gray
				'	Console.Write("Map 3: {0}", ScrambledMapPool(2))
				'End If
				Console.WriteLine("")
				Console.WriteLine("Series Score: {0}: {1} - {2}: {3}", Team1, Team1Maps, Team2, Team2Maps)
			End If
			Console.ReadLine()

			If ScrambledMapPool(MapsPlayed) = "Cache" Then
				SideCTPercent = 54
				SideTPercent = 46
			End If

			If ScrambledMapPool(MapsPlayed) = "Inferno" Then
				SideCTPercent = 49
				SideTPercent = 51
			End If

			If ScrambledMapPool(MapsPlayed) = "Cobblestone" Then
				SideCTPercent = 52
				SideTPercent = 48
			End If

			If ScrambledMapPool(MapsPlayed) = "Mirage" Then
				SideCTPercent = 54
				SideTPercent = 46
			End If

			If ScrambledMapPool(MapsPlayed) = "Nuke" Then
				SideCTPercent = 60
				SideTPercent = 40
			End If

			If ScrambledMapPool(MapsPlayed) = "Overpass" Then
				SideCTPercent = 57
				SideTPercent = 43
			End If

			If ScrambledMapPool(MapsPlayed) = "Train" Then
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
			Else
				Console.WriteLine("Select the starting side of {0} now.", Team1)
				Console.WriteLine("1. CT")
				Console.WriteLine("2. T")
				StartingSide = Console.ReadLine
				While StartingSide <> "1" And StartingSide <> "2"
					Console.WriteLine("That is not valid, try again.")
					StartingSide = Console.ReadLine
				End While
				If StartingSide = "1" Then
					SideCT = Team1
					Team1Side = "CT"
					SideT = Team2
					Team2Side = "T"
				Else
					SideT = Team1
					Team1Side = "T"
					SideCT = Team2
					Team2Side = "CT"
				End If
			End If
			If SlowDown = True Then
				System.Threading.Thread.Sleep(3000)
			End If
			Dim LO3 As Integer = 3
			Dim Countdown
			For Countdown = 1 To 3
				Console.WriteLine("Going live in {0}...", LO3)
				LO3 = LO3 - 1
				If SlowDown = True Then
					System.Threading.Thread.Sleep(1000)
				End If
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
				For PlayerKillsInteger As Integer = 0 To 9
					PlayerKills(PlayerKillsInteger) = 0
					PlayerDeaths(PlayerKillsInteger) = 0
				Next
				Do Until WinningScores.Contains(Team1Score) AndAlso Team2Score < Team1Score - 1 Or WinningScores.Contains(Team2Score) AndAlso Team1Score < Team2Score - 1
					i = i + 1
					'Wait between round beginnings and endings
					If i > 1 Then
						Console.WriteLine("")
						Sleeping()
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
						MapHalftimeScores(MapsPlayed, i / 15) = String.Join(" - ", Team1Score, Team2Score)
						Dim Timer As Integer = 5
						Sleeping()
						Console.Clear()
						Console.WriteLine("Breaking for half time...")
						Sleeping()
						If SlowDown = True Then
							For HalfTimeCount = 1 To 5
								Console.WriteLine("Resuming in {0}...", Timer)
								System.Threading.Thread.Sleep(1000)
								Timer = Timer - 1
								If HalfTimeCount = 5 Then
									Console.Clear()
								End If
							Next
						End If
						Console.WriteLine("The score is currently ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
						Sleeping()
					End If
					'Begin round + round mechanics
					RandomWinner = Rand.Next(0, 101)
					If Team1Score = 45 And Team2Score < 45 Then
						RandomWinner = 100
					End If
					If Team2Score = 45 And Team1Score < 45 Then
						RandomWinner = 0
					End If
					Scoreboard(SideCT, SideT)
					Console.WriteLine("Round {0} has begun...", i)
					Sleeping()
					Dim PlayersAlive(9) As String
					Dim RoundOver As Boolean = False
					Dim Killer As Integer
					Dim Victim As Integer
					Dim KillValid As Boolean = False
					Dim Team1Dead As Boolean = False
					Dim Team2Dead As Boolean = False
					For alive = 0 To 9
						PlayersAlive(alive) = "Alive"
					Next
					MapsPlayedCounter = MapsPlayed

					Do Until RoundOver = True
						Dim PrintedKill As Boolean = False
						KillValid = False
						Do Until KillValid = True
							Killer = Rand.Next(0, 10)
							Victim = Rand.Next(0, 10)
							Dim RandomChance As Integer = Rand.Next(0, 1)
							If Killer <> Victim And PlayersAlive(Killer) = "Alive" And PlayersAlive(Victim) = "Alive" And ((Killer < 5 And Victim >= 5) Or (Killer >= 5 And Victim < 5)) Then
								KillValid = True
								PlayersAlive(Victim) = "Dead"
							End If
						Loop

						PlayerKills(Killer) = PlayerKills(Killer) + 1
						PlayerDeaths(Victim) = PlayerDeaths(Victim) + 1
						PlayerKillsTotal(MapsPlayed, Killer) = PlayerKillsTotal(MapsPlayed, Killer) + 1
						PlayerDeathsTotal(MapsPlayed, Victim) = PlayerDeathsTotal(MapsPlayed, Victim) + 1

						Do Until PrintedKill = True
							If Killer < 5 And Team1 = SideCT Then
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("{0}.", Players(Victim))
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer < 5 And Team1 = SideT Then
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("{0}.", Players(Victim))
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer >= 5 And Team2 = SideCT Then
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("{0}.", Players(Victim))
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer >= 5 And Team2 = SideT Then
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("{0}.", Players(Victim))
								Console.ResetColor()
								PrintedKill = True
							Else
								Console.WriteLine("What the fuck you dimwit? {0} killed {1}", Players(Killer), Players(Victim))
								PrintedKill = True
							End If
						Loop
						Sleeping()
						Dim PlayersDeadListTeam1 As New List(Of String)
						Dim PlayersDeadListTeam2 As New List(Of String)
						For alive = 0 To 4
							If PlayersAlive(alive) = "Dead" Then
								PlayersDeadListTeam1.Add(PlayersAlive(alive))
							End If
						Next
						For alive = 5 To 9
							If PlayersAlive(alive) = "Dead" Then
								PlayersDeadListTeam2.Add(PlayersAlive(alive))
							End If
						Next
						If PlayersDeadListTeam1.Count = "5" Then
							Team2Score = Team2Score + 1
							Console.WriteLine(vbCrLf + "({0}) The score is now ({1}) {2}: {3} - ({4}) {5}: {6}", ScrambledMapPool(MapsPlayed), Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
							RoundOver = True
						End If
						If PlayersDeadListTeam2.Count = "5" Then
							Team1Score = Team1Score + 1
							Console.WriteLine(vbCrLf + "({0}) The score is now ({1}) {2}: {3} - ({4}) {5}: {6}", ScrambledMapPool(MapsPlayed), Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
							RoundOver = True
						End If
					Loop

					'If RandomWinner >= SideTPercent Then
					'    If SideCT = Team1 Then
					'        Team1Score = Team1Score + 1
					'        Console.WriteLine("{0} has taken the round.", Team1)
					'        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
					'    Else
					'        Team2Score = Team2Score + 1
					'        Console.WriteLine("{0} has taken the round.", Team2)
					'        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
					'    End If
					'Else
					'    If SideT = Team1 Then
					'        Team1Score = Team1Score + 1
					'        Console.WriteLine("{0} has taken the round.", Team1)
					'        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
					'    Else
					'        Team2Score = Team2Score + 1
					'        Console.WriteLine("{0} has taken the round.", Team2)
					'        Console.WriteLine("The score is now ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
					'    End If
					'End If

				Loop

				Sleeping()

				If Team1Score > Team2Score Then
					Team1Maps = Team1Maps + 1
					Console.WriteLine("{0} have took Map {1}", Team1, ScrambledMapPool(MapsPlayed))
				Else
					Team2Maps = Team2Maps + 1
					Console.WriteLine("{0} have took Map {1}", Team2, ScrambledMapPool(MapsPlayed))
				End If

				If Team1Score > Team2Score Then
					MapWinners(MapsPlayed) = Team1
					MapLosers(MapsPlayed) = Team2
					MapScores(MapsPlayed) = String.Join(" - ", Team1Score, Team2Score)
				ElseIf Team2Score > Team1Score Then
					MapWinners(MapsPlayed) = Team2
					MapLosers(MapsPlayed) = Team1
					MapScores(MapsPlayed) = String.Join(" - ", Team2Score, Team1Score)
				End If

				'If MapsPlayed = 0 And Team1Score > Team2Score Then
				'	Map1Winner = Team1
				'	Map1Loser = Team2
				'	Map1Score = String.Join(" - ", Team1Score, Team2Score)
				'End If

				'If MapsPlayed = 0 And Team1Score < Team2Score Then
				'	Map1Winner = Team2
				'	Map1Loser = Team1
				'	Map1Score = String.Join(" - ", Team2Score, Team1Score)
				'End If

				'If MapsPlayed = 1 And Team1Score > Team2Score Then
				'	Map2Winner = Team1
				'	Map2Loser = Team2
				'	Map2Score = String.Join(" - ", Team1Score, Team2Score)
				'End If

				'If MapsPlayed = 1 And Team1Score < Team2Score Then
				'	Map2Winner = Team2
				'	Map2Loser = Team1
				'	Map2Score = String.Join(" - ", Team2Score, Team1Score)
				'End If

				'If MapsPlayed = 2 And Team1Score > Team2Score Then
				'	Map3Winner = Team1
				'	Map3Loser = Team2
				'	Map3Score = String.Join(" - ", Team1Score, Team2Score)
				'End If

				'If MapsPlayed = 2 And Team1Score < Team2Score Then
				'	Map3Winner = Team2
				'	Map3Loser = Team1
				'	Map3Score = String.Join(" - ", Team2Score, Team1Score)
				'End If

				If Team1Maps = BestOfWin Then
					Sleeping()
					Exit For
				End If

				If Team2Maps = BestOfWin Then
					Sleeping()
					Exit For
				End If
				If SlowDown = True Then
					System.Threading.Thread.Sleep(Rand.Next(3000, 6001))
				End If
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
						Sleeping()
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
						Sleeping()
						Console.Clear()
						Console.WriteLine("Breaking for half time...")
						Sleeping()
						For HalfTimeCount = 1 To 5
							Console.WriteLine("Resuming in {0}...", Timer)
							System.Threading.Thread.Sleep(1000)
							Timer = Timer - 1
							If HalfTimeCount = 5 Then
								Console.Clear()
							End If
						Next
						Console.WriteLine("The score is currently ({0}) {1}: {2} - ({3}) {4}: {5}", Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
						Sleeping()
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
		Sleeping()
		DetermWinBO3()
	End Sub

	Sub OvertimeFalse()
		Console.WriteLine("This is deprecated, returning to menu in...")
		For i = 2 To 0 Step -1
			Console.WriteLine("{0}...", i)
			Threading.Thread.Sleep(1000)
		Next
		Main()
	End Sub

	'Sub DetermWin()
	'	Console.Clear()
	'	Dim Winner As String = ""
	'	If Team1Score > Team2Score Then
	'		Winner = Team1
	'	Else
	'		Winner = Team2
	'	End If
	'	If Team1Score = Team2Score Then
	'		Winner = "Draw"
	'	End If
	'	If Winner <> "Draw" Then
	'		Console.WriteLine("The winner is {0}.", Winner)
	'	Else
	'		Console.WriteLine("The game ended as a draw.")
	'	End If
	'	If Winner = Team1 Then
	'		Console.WriteLine("Map Score:")
	'		Console.WriteLine("Map 1 ({0}): {1}: {2} - {3}: {4}", ScrambledMapPool(0), Team1, Team1Score, Team2, Team2Score)
	'	Else
	'		Console.WriteLine("Map Score:")
	'		Console.WriteLine("Map 1 ({0}): {1}: {2} - {3}: {4}", ScrambledMapPool(0), Team2, Team2Score, Team1, Team1Score)
	'	End If
	'	Console.WriteLine("1. Score")
	'	Console.WriteLine("2. Stats Overall")
	'	Console.WriteLine("3. Main Menu")
	'	Dim UserInput As String = Console.ReadLine
	'	Select Case UserInput
	'		Case 1
	'			DetermWin()
	'		Case 2
	'			ScoreboardTotal()
	'		Case 3
	'			Main()
	'		Case Else
	'			DetermWin()
	'	End Select
	'End Sub

	Sub DetermWinBO3()
		Console.Clear()
		Dim Winner As String = ""
		If Team1Maps > Team2Maps Then
			Winner = Team1
		Else
			Winner = Team2
		End If
		If Team1Maps = Team2Maps Then
			Winner = "Draw"
		End If
		If Winner <> "Draw" Then
			Console.WriteLine("The winner is {0}.", Winner)
		End If
		If Winner = Team2 Then
			Console.WriteLine("The series score ended as {0} - {1}.", Team2Maps, Team1Maps)
		Else
			Console.WriteLine("The series score ended as {0} - {1}.", Team1Maps, Team2Maps)
		End If
		Console.WriteLine("")
		Console.WriteLine("Map Scores:")
		For i = 0 To MapsPlayedCounter
			Console.Write(vbCrLf + "Map {0} ({1}): {2}: {3} {4}", i + 1, ScrambledMapPool(i), MapWinners(i), MapScores(i), MapLosers(i))
			For HalftimePrint As Integer = 0 To 9
				If MapHalftimeScores(i, HalftimePrint) <> "" Then
					Console.Write(" / {0} {1} {2}", Team1, MapHalftimeScores(i, HalftimePrint), Team2)
				End If
			Next
		Next
		Console.WriteLine("")
		Console.WriteLine("1. Scores")
		Console.WriteLine("2. Stats Overall")
		Console.WriteLine("3. Stats Per Map")
		Console.WriteLine("4. Main Menu")
		Dim UserInput As String = Console.ReadLine
		Select Case UserInput
			Case 1
				DetermWinBO3()
			Case 2
				ScoreboardTotal()
			Case 3
				ScoreboardPerMap()
			Case 4
				Main()
			Case Else
				DetermWinBO3()
		End Select
		Console.ReadLine()
		DetermWinBO3()
	End Sub

	Sub Maps()
		ChooseMaps = True
		MapPool(0) = "Cache"
		MapPool(1) = "Cobblestone"
		MapPool(2) = "Inferno"
		MapPool(3) = "Mirage"
		MapPool(4) = "Nuke"
		MapPool(5) = "Overpass"
		MapPool(6) = "Train"
		Array.Clear(ScrambledMapPool, 0, ScrambledMapPool.Length)
		For i = 0 To 6
			Console.Clear()
			Console.WriteLine("Choose a map:")
			For maps As Integer = 0 To 6
				Console.Write("{0}. ", maps)
				Console.Write(MapPool(maps))
				Console.WriteLine("")
			Next
			Dim UserMap As String
			UserMap = Console.ReadLine
			While ScrambledMapPool.Contains(MapPool(UserMap))
				Console.WriteLine("That is already part of the map pool, try again.")
				UserMap = Console.ReadLine
			End While
			For maps As Integer = 0 To 6
				If UserMap = maps Then
					ScrambledMapPool(i) = MapPool(UserMap)
				End If
			Next
		Next
		Console.Clear()
		For i = 0 To 6
			Console.WriteLine(ScrambledMapPool(i))
		Next
		Console.ReadLine()
		Main()
	End Sub
	Sub Scoreboard(ByVal SideCT, ByVal SideT)
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next
		'Team1
		Console.WriteLine("{0} K/D", Team1)
		For i = 0 To 4
			If Team1 = SideCT Then
				Console.ForegroundColor = ConsoleColor.Blue
			Else
				Console.ForegroundColor = ConsoleColor.Red
			End If
			Console.WriteLine("{0} {1}/{2}", Players(i), PlayerKills(i), PlayerDeaths(i))
		Next
		Console.ResetColor()
		Console.WriteLine()
		Console.WriteLine("{0} K/D", Team2)
		For i = 5 To 9
			If Team2 = SideCT Then
				Console.ForegroundColor = ConsoleColor.Blue
			Else
				Console.ForegroundColor = ConsoleColor.Red
			End If
			Console.WriteLine("{0} {1}/{2}", Players(i), PlayerKills(i), PlayerDeaths(i))
		Next
		Console.ResetColor()
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next
	End Sub

	Sub ScoreboardTotal()
		Console.Clear()
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next

		'Team1
		Console.WriteLine("{0} K/D", Team1)
		For i = 0 To 4
			Dim TotalKillsPlayer As Integer = 0
			Dim TotalDeathsPlayer As Integer = 0
			Dim TotalKDRatio As Double = 0
			If Team1 = SideCT Then
				Console.ForegroundColor = ConsoleColor.Blue
			Else
				Console.ForegroundColor = ConsoleColor.Red
			End If
			For j = 0 To 6
				TotalKillsPlayer = TotalKillsPlayer + PlayerKillsTotal(j, i)
				TotalDeathsPlayer = TotalDeathsPlayer + PlayerDeathsTotal(j, i)
			Next
			TotalKDRatio = TotalKillsPlayer / TotalDeathsPlayer
			TotalKDRatio = Math.Round(TotalKDRatio, 2)
			Console.WriteLine("{0} {1}/{2} - {3} KD", Players(i), TotalKillsPlayer, TotalDeathsPlayer, TotalKDRatio)
		Next
		Console.ResetColor()
		Console.WriteLine()
		Console.WriteLine("{0} K/D", Team2)
		For i = 5 To 9
			Dim TotalKillsPlayer As Integer = 0
			Dim TotalDeathsPlayer As Integer = 0
			Dim TotalKDRatio As Double = 0
			If Team2 = SideCT Then
				Console.ForegroundColor = ConsoleColor.Blue
			Else
				Console.ForegroundColor = ConsoleColor.Red
			End If
			For j = 0 To 6
				TotalKillsPlayer = TotalKillsPlayer + PlayerKillsTotal(j, i)
				TotalDeathsPlayer = TotalDeathsPlayer + PlayerDeathsTotal(j, i)
			Next
			TotalKDRatio = TotalKillsPlayer / TotalDeathsPlayer
			TotalKDRatio = Math.Round(TotalKDRatio, 2)
			Console.WriteLine("{0} {1}/{2} - {3} KD", Players(i), TotalKillsPlayer, TotalDeathsPlayer, TotalKDRatio)
		Next

		Console.ResetColor()
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next
	End Sub

	Sub ScoreboardPerMap()
		Console.Clear()
		For j = 0 To MapsPlayedCounter
			Console.WriteLine("Map {0}: {1}", j + 1, MapsPlayedList(j))
			For i = 0 To Console.WindowWidth - 1
				Console.Write("=")
			Next
			'Team1
			Console.WriteLine("{0} K/D", Team1)
			For i = 0 To 4
				Dim TotalKDRatio As Double = 0
				If Team1 = SideCT Then
					Console.ForegroundColor = ConsoleColor.Blue
				Else
					Console.ForegroundColor = ConsoleColor.Red
				End If
				TotalKDRatio = Math.Round(PlayerKillsTotal(j, i) / PlayerDeathsTotal(j, i), 2)
				Console.WriteLine("{0} {1}/{2} - {3} KD", Players(i), PlayerKillsTotal(j, i), PlayerDeathsTotal(j, i), TotalKDRatio)
			Next
			Console.ResetColor()
			Console.WriteLine()
			Console.WriteLine("{0} K/D", Team2)
			For i = 5 To 9
				Dim TotalKDRatio As Double = 0
				If Team2 = SideCT Then
					Console.ForegroundColor = ConsoleColor.Blue
				Else
					Console.ForegroundColor = ConsoleColor.Red
				End If
				TotalKDRatio = Math.Round(PlayerKillsTotal(j, i) / PlayerDeathsTotal(j, i), 2)
				Console.WriteLine("{0} {1}/{2} - {3} KD", Players(i), PlayerKillsTotal(j, i), PlayerDeathsTotal(j, i), TotalKDRatio)
			Next
			Console.ResetColor()
			For i = 0 To Console.WindowWidth - 1
				Console.Write("=")
			Next
		Next

	End Sub

	Sub Sleeping()
		If SlowDown = True Then
			Threading.Thread.Sleep(Rand.Next(500, 2501))
		End If
	End Sub
End Module
