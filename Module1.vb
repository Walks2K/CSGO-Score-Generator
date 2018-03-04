Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module Module1
	Public Team1 As String
	Public Team2 As String
	Public Team1Score As Integer
	Public Team2Score As Integer
	Public Rand As New Random
	Public RandomWinner As Integer = Rand.Next(0, 101)
	Public HalfTime As Boolean = My.Settings.HalfTime
	Public KnifeRound As Boolean = My.Settings.KnifeRound
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
	Public PlayerKillsWeapons As DataTable = GetTable()
	Public PlayerKillsWeaponsTotal As DataTable = GetTable()
	Public PlayerMoney(9) As Integer
	Public PlayerWeapons(1, 9)
	Public Team1Force As Integer
	Public Team2Force As Integer
	Public Team1LossBonus As Integer = 1400
	Public Team2LossBonus As Integer = 1400
	Public MapsPlayedCounter As Integer
	Public MapsPlayedList(6) As String
	Public ClearConsole As Boolean = My.Settings.ClearConsole
	Public SupportedTeams(,) As String =
	{{"G2", "shox", "apEX", "kennyS", "NBK-", "bodyy", "80"},
	{"North", "MSL", "Kjaerbye", "cajunb", "aizy", "valde", "50"},
	{"Thieving Esports", "smokeyy2k", "scuffyG", "hoogler", "khalifa", "Basher", "80"},
	{"de_wey", "AaronM", "Hathus", "ArcherAce", "HizY", "MEERKAT", "80"},
	{"fnatic", "flusha", "KRIMZ", "JW", "Golden", "Lekr0", "70"},
	{"SK", "fer", "coldzera", "FalleN", "TACO", "boltz", "60"},
	{"FaZe", "karrigan", "olofmeister", "Guardian", "NiKo", "rain", "65"},
	{"Astralis", "Xyp9x", "dupreeh", "device", "gla1ve", "magisk", "40"},
	{"Gambit", "AdreN", "Dosia", "mou", "HObbit", "fitch", "40"},
	{"Natus Vincere", "Edward", "Zeus", "seized", "flamie", "s1mple", "50"},
	{"NTC", "bit1", "steel", "HEN1", "LUCAS1", "felps", "90"},
	{"Virtus.Pro", "TaZ", "NEO", "pashaBiceps", "Snax", "byali", "30"},
	{"Cloud9", "Skadoodle", "RUSH", "tarik", "autimatic", "Stewie2K", "60"},
	{"EnVyUs", "kio", "RpK", "ScreaM", "Happy", "hatji", "80"},
	{"NiP", "f0rest", "GeT_RiGhT", "Dennis", "draken", "REZ", "60"},
	{"BIG", "gob b", "LEGIJA", "tabseN", "keev", "nex", "60"},
	{"mousesports", "oskar", "chrisJ", "suNny", "STYKO", "ropz", "60"},
	{"Liquid", "nitr0", "jdm64", "stanislaw", "EliGE", "Twistzz", "60"},
	{"Heroic", "MODDII", "Snappi", "es3tag", "JUGi", "niko", "60"},
	{"CLG", "FNS", "reltuC", "Rickeh", "koosta", "nahtE", "60"},
	{"Renegades", "jks", "AZR", "NAF", "USTILO", "Nifty", "60"},
	{"HellRaisers", "ANGE1", "Zero", "woxic", "DeadFox", "ISSAA", "60"},
	{"FlipSid3", "markeloff", "B1ad3", "WorldEdit", "wayLander", "electronic", "60"},
	{"Space Soldiers", "MAJ3R", "XANTARES", "Calyx", "paz", "ngiN", "60"},
	{"AVANGAR", "qikert", "KrizzeN", "buster", "Jame", "dimasick", "60"},
	{"Vega Squadron", "hutji", "jR", "keshandr", "mir", "chopper", "60"}}
	Public SlowDown As Boolean = My.Settings.SlowDown
	Public SimulateGames As Boolean = False
	Public ReportBuys As Boolean = My.Settings.ReportBuys
	Public FullBuyCT(,) As String =
		{{"Famas", "2250", "300"},
		{"M4", "3100", "300"},
		{"AWP", "4750", "150"}}
	Public FullBuyT(,) As String =
		{{"UMP-45", "1200", "600"},
		{"AK-47", "2700", "300"},
		{"AWP", "4750", "300"}}
	Public PistolBuyCT(,) As String =
		{{"P250", "300", "300", "1"},
		{"CZ-75", "500", "150", "1"},
		{"Deagle", "700", "300", "1"},
		{"UMP-45", "1200", "600", "0"},
		{"MP9", "1250", "600", "0"}}
	Public PistolBuyT(,) As String =
		{{"P250", "300", "300", "1"},
		{"CZ-75", "500", "150", "1"},
		{"Deagle", "700", "300", "1"},
		{"MAC-10", "1050", "600", "0"},
		{"UMP-45", "1200", "600", "0"}}
	Public DefaultPistols(,) As String =
		{{"USP", "0", "300"},
		{"Glock", "0", "300"}}
	Public location As String = System.Environment.GetCommandLineArgs()(0)
	Public appName As String = System.IO.Path.GetFileName(location)
	Public Teams As String = System.AppDomain.CurrentDomain.BaseDirectory & "\" + appName + "_teams.txt"

	Public Sub Main()
		Console.Clear()

		PlayerKillsWeapons.Clear()
		PlayerKillsWeaponsTotal.Clear()
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
		Console.WriteLine("5. Simulate Games?: {0}", SimulateGames)
		Dim UserChoice As String = Console.ReadLine
		Select Case UserChoice
			Case 1
				GameSetup()
			Case 2
				Configure()
			Case 3
				Maps()
			Case 4
				ChooseMaps = Not (ChooseMaps)
				Main()
			Case 5
				SimulateGames = Not (SimulateGames)
				Main()
			Case 6
				Pickem()
			Case Else
				Main()
		End Select
	End Sub
	Sub Configure()
		Console.Clear()
		Console.WriteLine("1. Half Time: {0}", HalfTime)
		Console.WriteLine("2. Knife Round: {0}", KnifeRound)
		Console.WriteLine("3. Slow Down: {0}", SlowDown)
		Console.WriteLine("4. Clear Console at Halftimes: {0}", ClearConsole)
		Console.WriteLine("5. Show weapon purchases (mostly debugging purpose): {0}", ReportBuys)
		Console.WriteLine("9. Home")

		Dim UserChoice As String = Console.ReadLine
		Select Case UserChoice
			Case 1
				HalfTime = Not (HalfTime)
				Configure()
			Case 2
				KnifeRound = Not (KnifeRound)
				Configure()
			Case 3
				SlowDown = Not (SlowDown)
				Configure()
			Case 4
				ClearConsole = Not (ClearConsole)
				Configure()
			Case 5
				ReportBuys = Not (ReportBuys)
				Configure()
			Case 9
				SaveSettings()
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
		Dim Team1Valid As Boolean = False

		For i As Integer = 0 To SupportedTeams.GetUpperBound(0)
			If Team1 = SupportedTeams(i, 0) Then
				Team1Valid = True
				For j = 1 To 5
					Players(j - 1) = SupportedTeams(i, j)
				Next
				Team1Force = SupportedTeams(i, 6)
			End If
		Next

		If Team1Valid = False Then
			For i = 0 To 5
				If i < 5 Then
					Console.WriteLine("Enter the name of player {0} now.", i + 1)
					Players(i) = Console.ReadLine
				Else
					Console.WriteLine("Enter the chance of this team force buying now. (0% - 100%)")
					Try
						Team1Force = Console.ReadLine
					Catch ex As Exception
						Console.WriteLine("Not valid, resetting.")
						Threading.Thread.Sleep(1000)
						GameSetup()
					End Try
				End If
			Next
		End If
		Console.Clear()

		Console.WriteLine("Please enter the name of the second team now.")
		Team2 = Console.ReadLine
		Dim Team2Valid As Boolean = False

		For i As Integer = 0 To SupportedTeams.GetUpperBound(0)
			If Team2 = SupportedTeams(i, 0) Then
				Team2Valid = True
				For j = 1 To 5
					Players(j + 4) = SupportedTeams(i, j)
				Next
				Team2Force = SupportedTeams(i, 6)
			End If
		Next

		If Team2Valid = False Then
			For i = 5 To 10
				If i < 10 Then
					Console.WriteLine("Enter the name of player {0} now.", i + 1)
					Players(i) = Console.ReadLine
				Else
					Console.WriteLine("Enter the chance of this team force buying now. (0% - 100%)")
					Try
						Team2Force = Console.ReadLine
					Catch ex As Exception
						Console.WriteLine("Not valid, resetting.")
						Threading.Thread.Sleep(1000)
						GameSetup()
					End Try
				End If
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
		If SimulateGames = True Then
			Simulate()
		Else
			If Overtime = "Y" Then
				OvertimeTrue()
			End If

			If Overtime = "N" Then
				OvertimeFalse()
			End If
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
				Dim WinningScores(99) As Integer
				WinningScores(0) = "16"
				For WinningScoresLoop As Integer = 1 To 99 Step 1
					WinningScores(WinningScoresLoop) = 16 + (3 * WinningScoresLoop)
				Next

				'Max Rounds // DEPRECATED
				Dim MaxRounds(10) As Integer
				MaxRounds(0) = "30"
				For WinningScoresLoop As Integer = 1 To 10 Step 1
					MaxRounds(WinningScoresLoop) = 30 + (6 * WinningScoresLoop)
				Next

				'Half times
				Dim HalfTimes(99) As Integer
				HalfTimes(0) = "16"
				For WinningScoresLoop As Integer = 1 To 99 Step 1
					HalfTimes(WinningScoresLoop) = 28 + (3 * WinningScoresLoop)
				Next

				Dim PistolRounds() As Integer = {1, 16}

				'Start game
				Team1LossBonus = 1400
				Team2LossBonus = 1400
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
						If i > 16 Then
							For MoneySet = 0 To 9
								PlayerMoney(MoneySet) = 10000
							Next
						End If
					End If
					If HalfTimes.Contains(i) And HalfTime = True Then
						MapHalftimeScores(MapsPlayed, i / 15) = String.Join(" - ", Team1Score, Team2Score)
						Dim Timer As Integer = 5
						Sleeping()
						If ClearConsole = True Then
							Console.Clear()
						End If
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

					'Pistol Round/Reset Logic
					If PistolRounds.Contains(i) Then
						For PlayerMoneyReset = 0 To 9
							PlayerMoney(PlayerMoneyReset) = 150
							PlayerWeapons(0, PlayerMoneyReset) = ""
						Next
						If Team1 = SideCT Then
							For WeaponReset = 0 To 4
								PlayerWeapons(1, WeaponReset) = "USP"
							Next
							For WeaponReset = 5 To 9
								PlayerWeapons(1, WeaponReset) = "Glock"
							Next
						Else
							For WeaponReset = 0 To 4
								PlayerWeapons(1, WeaponReset) = "Glock"
							Next
							For WeaponReset = 5 To 9
								PlayerWeapons(1, WeaponReset) = "USP"
							Next
						End If
					End If

					If Team1 = SideCT Then
						For WeaponReset = 0 To 4
							If PlayerWeapons(1, WeaponReset) = "" Then
								PlayerWeapons(1, WeaponReset) = "USP"
							End If
						Next
						For WeaponReset = 5 To 9
							If PlayerWeapons(1, WeaponReset) = "" Then
								PlayerWeapons(1, WeaponReset) = "Glock"
							End If
						Next
					Else
						For WeaponReset = 0 To 4
							If PlayerWeapons(1, WeaponReset) = "" Then
								PlayerWeapons(1, WeaponReset) = "Glock"
							End If
						Next
						For WeaponReset = 5 To 9
							If PlayerWeapons(1, WeaponReset) = "" Then
								PlayerWeapons(1, WeaponReset) = "USP"
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
					For MoneyCheck = 0 To 9
						If PlayerMoney(MoneyCheck) > 16000 Then
							PlayerMoney(MoneyCheck) = 16000
						End If
					Next
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

					Dim FirstRun As Boolean = True
					BuyLogic(i, FirstRun)

					Scoreboard(SideCT, SideT)

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

						If PlayerWeapons(0, Killer) <> "" Then
							Dim MatchFound As Boolean = False
							For Each row As DataRow In PlayerKillsWeapons.Rows
								If row(0) = PlayerWeapons(0, Killer) And row(2) = Players(Killer) And row(5) = MapsPlayedCounter Then
									MatchFound = True
									row.SetField(0, PlayerWeapons(0, Killer))
									row.SetField(1, row.Field(Of Integer)(1) + 1)
									row.SetField(2, Players(Killer))
									row.SetField(3, Killer)
									row.SetField(4, MapsPlayedList(MapsPlayed))
									row.SetField(5, MapsPlayedCounter)
								End If
							Next

							If MatchFound = False Then
								PlayerKillsWeapons.Rows.Add(PlayerWeapons(0, Killer), 1, Players(Killer), Killer, MapsPlayedList(MapsPlayed), MapsPlayedCounter)
							End If
						Else
							Dim MatchFound As Boolean = False
							For Each row As DataRow In PlayerKillsWeapons.Rows
								If row(0) = PlayerWeapons(1, Killer) And row(2) = Players(Killer) And row(5) = MapsPlayedCounter Then
									MatchFound = True
									row.SetField(0, PlayerWeapons(1, Killer))
									row.SetField(1, row.Field(Of Integer)(1) + 1)
									row.SetField(2, Players(Killer))
									row.SetField(3, Killer)
									row.SetField(4, MapsPlayedList(MapsPlayed))
									row.SetField(5, MapsPlayedCounter)
								End If
							Next

							If MatchFound = False Then
								PlayerKillsWeapons.Rows.Add(PlayerWeapons(1, Killer), 1, Players(Killer), Killer, MapsPlayedList(MapsPlayed), MapsPlayedCounter)
							End If
						End If

						If PlayerWeapons(0, Killer) <> "" Then
							Dim MatchFound As Boolean = False
							For Each row As DataRow In PlayerKillsWeaponsTotal.Rows
								If row(0) = PlayerWeapons(0, Killer) And row(2) = Players(Killer) Then
									MatchFound = True
									row.SetField(0, PlayerWeapons(0, Killer))
									row.SetField(1, row.Field(Of Integer)(1) + 1)
									row.SetField(2, Players(Killer))
									row.SetField(3, Killer)
								End If
							Next

							If MatchFound = False Then
								PlayerKillsWeaponsTotal.Rows.Add(PlayerWeapons(0, Killer), 1, Players(Killer), Killer, MapsPlayedList(MapsPlayedCounter), MapsPlayedCounter)
							End If
						Else
							Dim MatchFound As Boolean = False
							For Each row As DataRow In PlayerKillsWeaponsTotal.Rows
								If row(0) = PlayerWeapons(1, Killer) And row(2) = Players(Killer) Then
									MatchFound = True
									row.SetField(0, PlayerWeapons(1, Killer))
									row.SetField(1, row.Field(Of Integer)(1) + 1)
									row.SetField(2, Players(Killer))
									row.SetField(3, Killer)
								End If
							Next

							If MatchFound = False Then
								PlayerKillsWeaponsTotal.Rows.Add(PlayerWeapons(1, Killer), 1, Players(Killer), Killer, MapsPlayedList(MapsPlayedCounter), MapsPlayedCounter)
							End If
						End If

						Dim KillRewardDone As Boolean = False

						Do Until KillRewardDone = True
							If PlayerWeapons(0, Killer) <> "" Then
								For KillReward = FullBuyT.GetLength(0) - 1 To 0 Step -1
									If PlayerWeapons(0, Killer) = FullBuyT(KillReward, 0) Then
										PlayerMoney(Killer) = PlayerMoney(Killer) + FullBuyT(KillReward, 2)
										KillRewardDone = True
									End If
								Next
								For KillReward = FullBuyCT.GetLength(0) - 1 To 0 Step -1
									If PlayerWeapons(0, Killer) = FullBuyCT(KillReward, 0) Then
										PlayerMoney(Killer) = PlayerMoney(Killer) + FullBuyCT(KillReward, 2)
										KillRewardDone = True
									End If
								Next
							Else
								For KillReward = PistolBuyCT.GetLength(0) - 1 To 0 Step -1
									If PlayerWeapons(1, Killer) = PistolBuyCT(KillReward, 0) Then
										PlayerMoney(Killer) = PlayerMoney(Killer) + PistolBuyCT(KillReward, 2)
										KillRewardDone = True
									End If
								Next
								For KillReward = PistolBuyT.GetLength(0) - 1 To 0 Step -1
									If PlayerWeapons(1, Killer) = PistolBuyT(KillReward, 0) Then
										PlayerMoney(Killer) = PlayerMoney(Killer) + PistolBuyT(KillReward, 2)
										KillRewardDone = True
									End If
								Next
								For KillReward = DefaultPistols.GetLength(0) - 1 To 0 Step -1
									If PlayerWeapons(1, Killer) = DefaultPistols(KillReward, 0) Then
										PlayerMoney(Killer) = PlayerMoney(Killer) + DefaultPistols(KillReward, 2)
										KillRewardDone = True
									End If
								Next
							End If
							KillRewardDone = True
						Loop

						'If PlayerWeapons(0, Killer) = "" Then
						'	PlayerWeapons(0, Killer) = PlayerWeapons(0, Victim)
						'End If

						PlayerWeapons(0, Victim) = ""
						PlayerWeapons(1, Victim) = ""

						Do Until PrintedKill = True
							If Killer < 5 And Team1 = SideCT Then
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("{0} ", Players(Victim))
								Console.ResetColor()
								If PlayerWeapons(0, Killer) <> "" Then
									Console.Write("with {0}", PlayerWeapons(0, Killer))
								Else
									Console.Write("with {0}", PlayerWeapons(1, Killer))
								End If
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer < 5 And Team1 = SideT Then
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("{0} ", Players(Victim))
								Console.ResetColor()
								If PlayerWeapons(0, Killer) <> "" Then
									Console.Write("with {0}", PlayerWeapons(0, Killer))
								Else
									Console.Write("with {0}", PlayerWeapons(1, Killer))
								End If
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer >= 5 And Team2 = SideCT Then
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("{0} ", Players(Victim))
								Console.ResetColor()
								If PlayerWeapons(0, Killer) <> "" Then
									Console.Write("with {0}", PlayerWeapons(0, Killer))
								Else
									Console.Write("with {0}", PlayerWeapons(1, Killer))
								End If
								Console.ResetColor()
								PrintedKill = True
							ElseIf Killer >= 5 And Team2 = SideT Then
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(vbCrLf + "{0} ", Players(Killer))
								Console.ResetColor()
								Console.Write("killed ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("{0} ", Players(Victim))
								Console.ResetColor()
								If PlayerWeapons(0, Killer) <> "" Then
									Console.Write("with {0}", PlayerWeapons(0, Killer))
								Else
									Console.Write("with {0}", PlayerWeapons(1, Killer))
								End If
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
							For PlayerBonus = 5 To 9
								PlayerMoney(PlayerBonus) = PlayerMoney(PlayerBonus) + 3250
							Next
							Team2LossBonus = 1400
							For PlayerBonus = 0 To 4
								PlayerMoney(PlayerBonus) = PlayerMoney(PlayerBonus) + Team1LossBonus
							Next
							Team1LossBonus = Team1LossBonus + 500
							Console.WriteLine(vbCrLf + "({0}) The score is now ({1}) {2}: {3} - ({4}) {5}: {6}", ScrambledMapPool(MapsPlayed), Team1Side, Team1, Team1Score, Team2Side, Team2, Team2Score)
							RoundOver = True
						End If

						If PlayersDeadListTeam2.Count = "5" Then
							Team1Score = Team1Score + 1
							For PlayerBonus = 0 To 4
								PlayerMoney(PlayerBonus) = PlayerMoney(PlayerBonus) + 3250
							Next
							Team1LossBonus = 1400
							For PlayerBonus = 5 To 9
								PlayerMoney(PlayerBonus) = PlayerMoney(PlayerBonus) + Team2LossBonus
							Next
							Team2LossBonus = Team2LossBonus + 500
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
		Console.WriteLine("This is deprecated, it will be added back after the OvertimeTrue sub is deemed finished, returning to menu in...")
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
		Console.WriteLine("" + vbCrLf)
		Console.WriteLine("1. Scores")
		Console.WriteLine("2. Stats Overall")
		Console.WriteLine("3. Stats Per Map")
		Console.WriteLine("4. Best Weapons Overall")
		Console.WriteLine("5. Best Weapons Per Map")
		Console.WriteLine("6. Main Menu")
		Dim UserInput As String = Console.ReadLine
		Select Case UserInput
			Case 1
				DetermWinBO3()
			Case 2
				ScoreboardTotal()
			Case 3
				ScoreboardPerMap()
			Case 4
				Stats()
			Case 5
				StatsPerMap()
			Case 6
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
			Try
				If UserMap > 6 Or UserMap < 0 Then
					Maps()
				End If
			Catch ex As Exception
				Maps()
			End Try
			'While ScrambledMapPool.Contains(MapPool(UserMap))
			'	Console.WriteLine("That is already part of the map pool, try again.")
			'	UserMap = Console.ReadLine
			'End While
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
			Console.WriteLine("{0} ${1} {2}/{3} / Primary: {4} Secondary: {5}", Players(i), PlayerMoney(i), PlayerKills(i), PlayerDeaths(i), PlayerWeapons(0, i), PlayerWeapons(1, i))
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
			Console.WriteLine("{0} ${1} {2}/{3} / Primary: {4} Secondary: {5}", Players(i), PlayerMoney(i), PlayerKills(i), PlayerDeaths(i), PlayerWeapons(0, i), PlayerWeapons(1, i))
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
			Threading.Thread.Sleep(Rand.Next(501, 1501))
		End If
	End Sub

	Sub Simulate()
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

		Console.Clear()

		Console.WriteLine("How many simulations would you like to do?")
		Dim SimulateAmount As Integer = Console.ReadLine

		For SimulateStart As Integer = 0 To SimulateAmount - 1
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
					System.Threading.Thread.Sleep(1500)
				End If
				Dim LO3 As Integer = 3
				Dim Countdown
				For Countdown = 1 To 3
					Console.WriteLine("Going live in {0}...", LO3)
					LO3 = LO3 - 1
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
		Next

		Sleeping()
		DetermWinSimulate()
	End Sub

	Sub DetermWinSimulate()
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
		Console.WriteLine("" + vbCrLf)
		Console.WriteLine("1. Scores")
		Console.WriteLine("2. Stats Overall")
		Console.WriteLine("3. Stats Per Map")
		Console.WriteLine("4. Main Menu")
		Dim UserInput As String = Console.ReadLine
		Select Case UserInput
			Case 1
				DetermWinSimulate()
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
		DetermWinSimulate()
	End Sub

	Function BuyLogic(ByVal i, ByVal FirstRun)
		'Buy Logic
		Dim Team1AwpCount As Integer = 0
		Dim Team2AwpCount As Integer = 0
		Dim GunBrought As Boolean = False

		For AWPCheck = 0 To 4
			If PlayerWeapons(0, AWPCheck) = "AWP" Then
				Team1AwpCount = Team1AwpCount + 1
			End If
		Next

		For AWPCheck = 5 To 9
			If PlayerWeapons(0, AWPCheck) = "AWP" Then
				Team2AwpCount = Team2AwpCount + 1
			End If
		Next

		Dim ForceBuy As Integer = Rand.Next(0, 101)

		If Team1 = SideCT Then
			ForceBuy = Rand.Next(0, 101)
			GunBrought = False
			If i = 2 Or i = 17 Then
				If ForceBuy < Team1Force Or Team1LossBonus = 1400 Then
					For BuyGuns = 0 To 4
						For PriceCheck = PistolBuyCT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) - 1000 > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyCT(PriceCheck, 3), BuyGuns) = PistolBuyCT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) - 1000
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyCT(PriceCheck, 0), PistolBuyCT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					Next
				End If
			Else
				For BuyGuns = 0 To 4
					If PlayerWeapons(0, BuyGuns) <> "" Then
						GunBrought = True
					Else
						GunBrought = False
					End If
					For PriceCheck = FullBuyCT.GetLength(0) - 1 To 0 Step -1
						If PlayerMoney(BuyGuns) > 0 And PlayerWeapons(0, BuyGuns) = "" And PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650 >= 0 Then
							If FullBuyCT(PriceCheck, 0) = "AWP" Then
								If Team1AwpCount < 2 Then
									PlayerWeapons(0, BuyGuns) = FullBuyCT(PriceCheck, 0)
									PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650
									GunBrought = True
									If ReportBuys = True Then
										Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyCT(PriceCheck, 0), FullBuyCT(PriceCheck, 1) + 650)
									End If
									Team1AwpCount = Team1AwpCount + 1
									Continue For
								Else
									Continue For
								End If
							End If
							PlayerWeapons(0, BuyGuns) = FullBuyCT(PriceCheck, 0)
							PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650
							If ReportBuys = True Then
								Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyCT(PriceCheck, 0), FullBuyCT(PriceCheck, 1) + 650)
							End If
							GunBrought = True
						End If
					Next

					If ForceBuy < Team1Force Or GunBrought = True Then
						For PriceCheck = PistolBuyCT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyCT(PriceCheck, 3), BuyGuns) = PistolBuyCT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1)
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyCT(PriceCheck, 0), PistolBuyCT(PriceCheck, 1))
								End If
								GunBrought = True
							End If
						Next
					End If
				Next
			End If

			ForceBuy = Rand.Next(0, 101)

			If i = 2 Or i = 17 Then
				If ForceBuy < Team2Force Or Team2Force = 1400 Then
					For BuyGuns = 5 To 9
						For PriceCheck = PistolBuyT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000 > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyT(PriceCheck, 3), BuyGuns) = PistolBuyT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyT(PriceCheck, 0), PistolBuyT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					Next
				End If
			Else
				For BuyGuns = 5 To 9
					If PlayerWeapons(0, BuyGuns) <> "" Then
						GunBrought = True
					Else
						GunBrought = False
					End If
					For PriceCheck = FullBuyT.GetLength(0) - 1 To 0 Step -1
						If PlayerMoney(BuyGuns) > 0 And PlayerWeapons(0, BuyGuns) = "" And PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000 >= 0 Then
							If FullBuyT(PriceCheck, 0) = "AWP" Then
								If Team2AwpCount < 2 Then
									PlayerWeapons(0, BuyGuns) = FullBuyT(PriceCheck, 0)
									PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000
									GunBrought = True
									If ReportBuys = True Then
										Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyT(PriceCheck, 0), FullBuyT(PriceCheck, 1) + 1000)
									End If
									Team2AwpCount = Team2AwpCount + 1
									Continue For
								Else
									Continue For
								End If
							End If
							PlayerWeapons(0, BuyGuns) = FullBuyT(PriceCheck, 0)
							PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000
							If ReportBuys = True Then
								Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyT(PriceCheck, 0), FullBuyT(PriceCheck, 1) + 1000)
							End If
							GunBrought = True
						End If
					Next

					If ForceBuy < Team2Force Or GunBrought = True Then
						For PriceCheck = PistolBuyT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyT(PriceCheck, 3), BuyGuns) = PistolBuyT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1)
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyT(PriceCheck, 0), PistolBuyT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					End If
				Next
			End If
		Else
			ForceBuy = Rand.Next(0, 101)
			If i = 2 Or i = 17 Then
				If ForceBuy < Team1Force Or Team1Force = 1400 Then
					For BuyGuns = 0 To 4
						For PriceCheck = PistolBuyT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000 > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyT(PriceCheck, 3), BuyGuns) = PistolBuyT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyT(PriceCheck, 0), PistolBuyT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					Next
				End If
			Else
				For BuyGuns = 0 To 4
					If PlayerWeapons(0, BuyGuns) <> "" Then
						GunBrought = True
					Else
						GunBrought = False
					End If
					For PriceCheck = FullBuyT.GetLength(0) - 1 To 0 Step -1
						If PlayerMoney(BuyGuns) > 0 And PlayerWeapons(0, BuyGuns) = "" And PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000 >= 0 Then
							If FullBuyT(PriceCheck, 0) = "AWP" Then
								If Team1AwpCount < 2 Then
									PlayerWeapons(0, BuyGuns) = FullBuyT(PriceCheck, 0)
									PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000
									If ReportBuys = True Then
										Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyT(PriceCheck, 0), FullBuyT(PriceCheck, 1) + 1000)
									End If
									Team1AwpCount = Team1AwpCount + 1
									GunBrought = True
									Continue For
								Else
									Continue For
								End If
							End If
							PlayerWeapons(0, BuyGuns) = FullBuyT(PriceCheck, 0)
							PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyT(PriceCheck, 1) - 1000
							If ReportBuys = True Then
								Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyT(PriceCheck, 0), FullBuyT(PriceCheck, 1) + 1000)
							End If
							GunBrought = True
						End If
					Next

					If ForceBuy < Team1Force Then
						For PriceCheck = PistolBuyT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000 > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyT(PriceCheck, 3), BuyGuns) = PistolBuyT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyT(PriceCheck, 1) - 1000
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyT(PriceCheck, 0), PistolBuyT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					End If
				Next
			End If

			ForceBuy = Rand.Next(0, 101)
			If i = 2 Or i = 17 Then
				If ForceBuy < Team2Force Or Team2Force = 1400 Then
					For BuyGuns = 5 To 9
						For PriceCheck = PistolBuyCT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) - 1000 > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyCT(PriceCheck, 3), BuyGuns) = PistolBuyCT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) - 1000
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyCT(PriceCheck, 0), PistolBuyCT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					Next
				End If
			Else
				For BuyGuns = 5 To 9
					If PlayerWeapons(0, BuyGuns) <> "" Then
						GunBrought = True
					Else
						GunBrought = False
					End If
					For PriceCheck = FullBuyCT.GetLength(0) - 1 To 0 Step -1
						If PlayerMoney(BuyGuns) > 0 And PlayerWeapons(0, BuyGuns) = "" And PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650 >= 0 Then
							If FullBuyCT(PriceCheck, 0) = "AWP" Then
								If Team2AwpCount < 2 Then
									PlayerWeapons(0, BuyGuns) = FullBuyCT(PriceCheck, 0)
									PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650
									If ReportBuys = True Then
										Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyCT(PriceCheck, 0), FullBuyCT(PriceCheck, 1) + 1000)
									End If
									Team2AwpCount = Team2AwpCount + 1
									GunBrought = True
									Continue For
								Else
									Continue For
								End If
							End If
							PlayerWeapons(0, BuyGuns) = FullBuyCT(PriceCheck, 0)
							PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - FullBuyCT(PriceCheck, 1) - 650
							If ReportBuys = True Then
								Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), FullBuyCT(PriceCheck, 0), FullBuyCT(PriceCheck, 1) + 1000)
							End If
							GunBrought = True
						End If
					Next
					If ForceBuy < Team2Force Then
						For PriceCheck = PistolBuyCT.GetLength(0) - 1 To 0 Step -1
							If PlayerMoney(BuyGuns) > 0 And PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1) > 0 And PlayerWeapons(0, BuyGuns) = "" Then
								PlayerWeapons(PistolBuyCT(PriceCheck, 3), BuyGuns) = PistolBuyCT(PriceCheck, 0)
								PlayerMoney(BuyGuns) = PlayerMoney(BuyGuns) - PistolBuyCT(PriceCheck, 1)
								If ReportBuys = True Then
									Console.WriteLine("{0} brought {1} for ${2}", Players(BuyGuns), PistolBuyCT(PriceCheck, 0), PistolBuyCT(PriceCheck, 1) + 1000)
								End If
								GunBrought = True
							End If
						Next
					End If
				Next
			End If

		End If
		If FirstRun = True Then
			FirstRun = False
			BuyLogic(i, FirstRun)
		End If

		Return True
	End Function

	Function GetTable() As DataTable
		' Create new DataTable instance.
		Dim table As New DataTable

		' Create four typed columns in the DataTable.
		table.Columns.Add("Weapon", GetType(String))
		table.Columns.Add("Count", GetType(Integer))
		table.Columns.Add("Player", GetType(String))
		table.Columns.Add("Player Index", GetType(Integer))
		table.Columns.Add("Map", GetType(String))
		table.Columns.Add("Map Index", GetType(Integer))
		Return table
	End Function

	Function GetTableTotal() As DataTable
		' Create new DataTable instance.
		Dim table As New DataTable

		' Create four typed columns in the DataTable.
		table.Columns.Add("Weapon", GetType(String))
		table.Columns.Add("Count", GetType(Integer))
		table.Columns.Add("Player", GetType(String))
		table.Columns.Add("Player Index", GetType(Integer))
		Return table
	End Function

	Sub Stats()
		Console.Clear()
		Dim dataView As New DataView(PlayerKillsWeaponsTotal)
		dataView.Sort = "Player Index DESC, Count DESC"
		PlayerKillsWeaponsTotal = dataView.ToTable
		Dim PreviousPlayer As String = Players(0)
		For Each row As DataRow In PlayerKillsWeaponsTotal.Rows
			If row.Field(Of String)(2) <> PreviousPlayer Then
				For i = 0 To Console.WindowWidth - 1
					Console.Write("=")
				Next
				Console.WriteLine("{0}:", row.Field(Of String)(2))
				PreviousPlayer = row.Field(Of String)(2)
			End If
			For i = 0 To 4
				If row.Field(Of String)(2) = Players(i) Then
					Console.ForegroundColor = ConsoleColor.Blue
					Exit For
				Else
					Console.ForegroundColor = ConsoleColor.Red
				End If
			Next
			Console.WriteLine("{0} - {1} kills", row.Field(Of String)(0), row.Field(Of Integer)(1))
			Console.ResetColor()
		Next
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next
	End Sub

	Sub StatsPerMap()
		Console.Clear()
		For i = 0 To Console.WindowWidth - 1
			Console.Write("=")
		Next
		For j = 0 To MapsPlayedCounter
			Console.WriteLine("Map {0}: {1}", j + 1, MapsPlayedList(j))
			Dim dataView As New DataView(PlayerKillsWeapons)
			dataView.Sort = "Player Index DESC, Count DESC"
			PlayerKillsWeapons = dataView.ToTable
			Dim PreviousPlayer As String = Players(0)
			For Each row As DataRow In PlayerKillsWeapons.Rows
				If row.Field(Of String)(2) <> PreviousPlayer Then
					For i = 0 To Console.WindowWidth - 1
						Console.Write("=")
					Next
					Console.WriteLine("{0} - {1}:", row.Field(Of String)(2), MapsPlayedList(j))
					PreviousPlayer = row.Field(Of String)(2)
				End If
				For i = 0 To 4
					If row.Field(Of String)(2) = Players(i) Then
						Console.ForegroundColor = ConsoleColor.Blue
						Exit For
					Else
						Console.ForegroundColor = ConsoleColor.Red
					End If
				Next
				If row.Field(Of Integer)(5) = j Then
					Console.WriteLine("{0} - {1} kills", row.Field(Of String)(0), row.Field(Of Integer)(1))
				End If
				Console.ResetColor()
			Next
			For i = 0 To Console.WindowWidth - 1
				Console.Write("=")
			Next
		Next
	End Sub

	Sub SaveSettings()
		My.Settings.HalfTime = HalfTime
		My.Settings.ReportBuys = ReportBuys
		My.Settings.ClearConsole = ClearConsole
		My.Settings.KnifeRound = KnifeRound
		My.Settings.SlowDown = SlowDown
		My.Settings.Save()
	End Sub

	Sub GamesSimulated()
		'Pseudo
		'Games Array that stores required values
	End Sub

	Sub Pickem()
		Console.Clear()
		Console.WriteLine("This is a simple pick-em generator inspired by the original version of this program. It will simply pick a winner each game at first but may use the whole stat system to get a full list of the players in the future.")
		Console.WriteLine("This needs to be done but im lazy")
	End Sub
End Module
