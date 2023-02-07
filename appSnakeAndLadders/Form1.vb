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

    'Keeps track of player scores
    Public player1Score As Integer = 1
    Public player2Score As Integer = 1

    'Keeps track of whether they have rolled a 6 (started playing)
    Public player1Playing As Boolean = False
    Public player2Playing As Boolean = False

    Dim intRollNumber As Integer

    'Generate a number between 1 and 6
    Private Function rollDie() As Integer
        Return random.Next(1, 7) 'Return a number from 1 to 6
    End Function

    'Toggles roll buttons and changes the text in lblPlayerTurn and lblState
    Private Sub updateForm()
        btnDie1.Enabled = Not btnDie1.Enabled
        btnDie2.Enabled = Not btnDie2.Enabled

        If strCurrentPlayer = "Player 1" Then
            lblPlayerTurn.Text = "Player 2's Turn"

            If player2Playing Then
                lblState.Text = "Get to 100 to win!"
            Else
                lblState.Text = "Roll a 6 to start playing!"
            End If
        Else
            lblPlayerTurn.Text = "Player 1's Turn"

            If player1Playing Then
                lblState.Text = "Get to 100 to win!"
            Else
                lblState.Text = "Roll a 6 to start playing!"
            End If
        End If
    End Sub

    Private Function calculateScore(intRollNumber As Integer) As String
        ' This is calculation of score for both players!
        If strCurrentPlayer = "Player 1" Then
            ' This is calculation of score for player 1
            If (player1Score + intRollNumber < 100) Then
                player1Score += intRollNumber
            ElseIf (player1Score + intRollNumber) = 100 Then
                player1Score += intRollNumber
                Return "Win"
            Else
                Return "Continue"
            End If

            Select Case player1Score
                ' This is  calculation of score for ladders.
                Case 2
                    player1Score = 38
                    Return "Ladder"
                Case 9
                    player1Score = 14
                    Return "Ladder"
                Case 15
                    player1Score = 82
                    Return "Ladder"
                Case 16
                    player1Score = 54
                    Return "Ladder"
                Case 50
                    player1Score = 91
                    Return "Ladder"
                Case 74
                    player1Score = 87
                    Return "Ladder"
              ' This is  calculation of score for snakes.
                Case 18
                    player1Score = 6
                    Return "Snake"
                Case 29
                    player1Score = 7
                    Return "Snake"
                Case 61
                    player1Score = 16
                    Return "Snake"
                Case 72
                    player1Score = 47
                    Return "Snake"
                Case 96
                    player1Score = 76
                    Return "Snake"
            End Select
        ElseIf strCurrentPlayer = "Player 2" Then
            ' This is calculation of score for player 2
            If (player2Score + intRollNumber < 100) Then
                player2Score += intRollNumber
            ElseIf (player2Score + intRollNumber) = 100 Then
                player2Score += intRollNumber
                Return "Win"
            Else
                Return "Continue"
            End If

            Select Case player2Score
                ' This is  calculation of score for ladders.
                Case 2
                    player2Score = 38
                    Return "Ladder"
                Case 9
                    player2Score = 14
                    Return "Ladder"
                Case 15
                    player2Score = 82
                    Return "Ladder"
                Case 16
                    player1Score = 54
                    Return "Ladder"
                Case 50
                    player2Score = 91
                    Return "Ladder"
                Case 74
                    player2Score = 87
                    Return "Ladder"
             ' This is  calculation of score for snakes.
                Case 18
                    player2Score = 6
                    Return "Snake"
                Case 29
                    player2Score = 7
                    Return "Snake"
                Case 61
                    player2Score = 16
                    Return "Snake"
                Case 72
                    player2Score = 47
                    Return "Snake"
                Case 96
                    player2Score = 76
                    Return "Snake"
            End Select
        End If

        Return "Playing"
    End Function

    Private Sub movePlayer(picPlayer As PictureBox, counter As Integer)
        Dim lblName As String = "lblCounter" + counter.ToString
        Dim lblCounter As Label = CType(Me.Controls(lblName), Label)

        picPlayer.Left = lblCounter.Left
        picPlayer.Top = lblCounter.Top
    End Sub

    Private Sub addHistory(outcome As String)
        Dim score As Integer

        If strCurrentPlayer = "Player 1" Then
            score = player1Score
        Else
            score = player2Score
        End If

        Select Case outcome
            Case "Start Playing"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has rolled a 6! They have now started playing"
            Case "Playing"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has moved to {score}"
            Case "Snake"
            Case "Ladder"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has landed on a {outcome.ToLower}! They move to {score}"
            Case "Continue"
                lblHistory.Text += $"{newline}{strCurrentPlayer} has rolled over 100! Roll to 100 exactly to win!"
        End Select
    End Sub

    'Main game logic here
    Private Sub takeTurn()
        intRollNumber = rollDie()
        updateForm()

        If strCurrentPlayer = "Player 1" Then
            setDiePic(intRollNumber, picDie1)

            If Not player1Playing Then
                If intRollNumber = 6 Then
                    player1Playing = True
                    addHistory("Start Playing")
                    Return
                Else
                    Return
                End If
            End If

            outcome = calculateScore(intRollNumber)
            addHistory(outcome)
            movePlayer(picPlayer1, player1Score)
        ElseIf strCurrentPlayer = "Player 2" Then
            setDiePic(intRollNumber, picDie2)

            If Not player2Playing Then
                If intRollNumber = 6 Then
                    player2Playing = True
                    addHistory("Start Playing")
                    Return
                Else
                    Return
                End If
            End If

            outcome = calculateScore(intRollNumber)
            addHistory(outcome)
            movePlayer(picPlayer2, player2Score)
        End If
    End Sub

    'Choose correct image for the die
    Private Sub setDiePic(intNumber As Integer, picBox As PictureBox)
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblHistory.Text = ""
    End Sub
End Class
