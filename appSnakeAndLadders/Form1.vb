Public Class Form1
    Dim random = New Random()

    'List of the pictures for the die faces
    Dim dieFaces = New List(Of Image) From {
        My.Resources.die1,
        My.Resources.die2,
        My.Resources.die3,
        My.Resources.die4,
        My.Resources.die5,
        My.Resources.die6
    }

    Dim newline As String = Environment.NewLine
    Dim outcome As String

    'Keeps track of who's turn it is
    Dim strCurrentPlayer As String = "Player 1"

    'Keeps track of player score and state
    Dim playerStats = New Dictionary(Of String, Dictionary(Of String, Object)) From {
        {"Player 1", New Dictionary(Of String, Object) From {
            {"Playing", False},
            {"Score", 1}
        }},
        {"Player 2", New Dictionary(Of String, Object) From {
            {"Playing", False},
            {"Score", 1}
        }}
    }

    Dim intRollNumber As Integer

    'Generate a number between 1 and 6
    Private Function rollDie() As Integer
        Return random.next(1, 7) 'return a number from 1 to 6
    End Function

    'Toggles roll buttons and changes the text in lblPlayerTurn and lblState
    Private Sub updateForm()
        btnDie1.Enabled = Not btnDie1.Enabled
        btnDie2.Enabled = Not btnDie2.Enabled

        lblPlayerTurn.Text = $"{strCurrentPlayer}'s Turn"

        If playerStats(strCurrentPlayer)("Playing") Then
            lblState.Text = "Get to 100 to win!"
        Else
            lblState.Text = "Roll a 6 to start playing!"
        End If
    End Sub

    Private Function checkTile(score As Integer) As String
        Select Case score
            ' This checks if a tile is the bottom of a ladder
            Case 2
                playerStats(strCurrentPlayer)("Score") = 38
                Return "Ladder"
            Case 9
                playerStats(strCurrentPlayer)("Score") = 14
                Return "Ladder"
            Case 15
                playerStats(strCurrentPlayer)("Score") = 82
                Return "Ladder"
            Case 16
                playerStats(strCurrentPlayer)("Score") = 54
                Return "Ladder"
            Case 50
                playerStats(strCurrentPlayer)("Score") = 91
                Return "Ladder"
            Case 74
                playerStats(strCurrentPlayer)("Score") = 87
                Return "Ladder"
           ' This checks if a tile is the head of a snake
            Case 18
                playerStats(strCurrentPlayer)("Score") = 6
                Return "Snake"
            Case 29
                playerStats(strCurrentPlayer)("Score") = 7
                Return "Snake"
            Case 61
                playerStats(strCurrentPlayer)("Score") = 16
                Return "Snake"
            Case 72
                playerStats(strCurrentPlayer)("Score") = 47
                Return "Snake"
            Case 96
                playerStats(strCurrentPlayer)("Score") = 76
                Return "Snake"
            Case Else
                Return "Playing"
        End Select
    End Function

    Private Function calculateScore(intRollNumber As Integer) As String
        Dim intPlayerScore As Integer = playerStats(strCurrentPlayer)("Score")

        If (intPlayerScore + intRollNumber) < 100 Then
            playerStats(strCurrentPlayer)("Score") += intRollNumber
        ElseIf (intPlayerScore + intRollNumber) = 100 Then
            playerStats(strCurrentPlayer)("Score") += intRollNumber
            Return "Win"
        Else
            Return "Continue"
        End If

        Return checkTile(intPlayerScore)
    End Function

    Private Sub movePlayer(counter As Integer)
        Dim lblName As String = "lblCounter" + counter.ToString
        Dim lblCounter As Label = CType(Me.Controls(lblName), Label)
        Dim picPlayer As PictureBox

        If strCurrentPlayer = "Player 1" Then
            picPlayer = picPlayer1
        Else
            picPlayer = picPlayer2
        End If

        picPlayer.Left = lblCounter.Left
        picPlayer.Top = lblCounter.Top
    End Sub

    Private Sub addHistory(outcome As String)
        Dim intPlayerScore As Integer = playerStats(strCurrentPlayer)("Score")

        Select Case outcome
            Case "Start Playing"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has rolled a 6! They have now started playing"
            Case "Playing"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has moved to {intPlayerScore}"
            Case "Snake"
            Case "Ladder"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has landed on a {outcome.ToLower}! They move to {intPlayerScore}"
            Case "Continue"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has rolled over 100! Roll to 100 exactly to win!"
        End Select
    End Sub

    Private Sub restart()
        playerStats("Player 1")("Playing") = False
        playerStats("Player 2")("Playing") = False
        playerStats("Player 1")("Score") = 1
        playerStats("Player 2")("Score") = 1
        lblHistory.Text = ""

        movePlayer(1)
        movePlayer(1)
        setDiePic(1)
        setDiePic(1)
    End Sub

    'Main game logic here
    Private Sub takeTurn()
        intRollNumber = rollDie()
        updateForm()
        setDiePic(intRollNumber)

        Dim intPlayerScore As Integer = playerStats(strCurrentPlayer)("Score")
        Dim boolPlaying As Boolean = playerStats(strCurrentPlayer)("Playing")

        If Not boolPlaying Then
            If intRollNumber = 6 Then
                playerStats(strCurrentPlayer)("Playing") = True
                addHistory("Start Playing")
                Return
            Else
                Return
            End If
        End If

        outcome = calculateScore(intRollNumber)
        movePlayer(intPlayerScore)
        addHistory(outcome)

        If outcome = "Win" Then
            MessageBox.Show("You've Won!", "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            restart()
        End If
    End Sub

    'Choose correct image for the die
    Private Sub setDiePic(intNumber As Integer)
        Dim picBox As PictureBox

        If strCurrentPlayer = "Player 1" Then
            picBox = picDie1
        Else
            picBox = picDie2
        End If

        picBox.Image = dieFaces(intNumber - 1)
    End Sub

    'Roll button for player 1 is clicked
    Private Sub btnDie1_Click(button As Object, e As EventArgs) Handles btnDie1.Click
        strCurrentPlayer = "Player 1"
        takeTurn()
    End Sub

    'Roll button for player 2 is clicked
    Private Sub btnDie2_Click(button As Object, e As EventArgs) Handles btnDie2.Click
        strCurrentPlayer = "Player 2"
        takeTurn()
    End Sub
End Class
