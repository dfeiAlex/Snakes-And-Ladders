Public Class Form1
    Dim game = New Game()

    Dim strCurrentPlayer As String = "Player 1"

    'List of the pictures for the die faces
    Dim dieFaces = New List(Of Image) From {
        My.Resources.die1,
        My.Resources.die2,
        My.Resources.die3,
        My.Resources.die4,
        My.Resources.die5,
        My.Resources.die6
    }

    'Toggles roll buttons and changes the text in lblPlayerTurn and lblState
    Private Sub updateForm()
        btnDie1.Enabled = Not btnDie1.Enabled
        btnDie2.Enabled = Not btnDie2.Enabled

        If strCurrentPlayer = "Player 1" Then
            lblPlayerTurn.Text = "Player 2's Turn"

            If game.player2Playing Then
                lblState.Text = "Get to 100 to win!"
            Else
                lblState.Text = "Roll a 6 to start playing!"
            End If
        Else
            lblPlayerTurn.Text = "Player 1's Turn"

            If game.player1Playing Then
                lblState.Text = "Get to 100 to win!"
            Else
                lblState.Text = "Roll a 6 to start playing!"
            End If
        End If
    End Sub

    'Main game logic here
    Private Sub takeTurn(strPlayer As String)


        updateForm()
    End Sub

    'Choose correct image for the die
    Private Sub setDiePic(intNumber As Integer, picBox As PictureBox)
        picBox.Image = dieFaces(intNumber - 1)
    End Sub

    'Roll button for player 1 is clicked
    Private Sub btnDie1_Click(button As Object, e As EventArgs) Handles btnDie1.Click
        strCurrentPlayer = "Player 1"
        takeTurn(strCurrentPlayer)
    End Sub

    'Roll button for player 2 is clicked
    Private Sub btnDie2_Click(button As Object, e As EventArgs) Handles btnDie2.Click
        strCurrentPlayer = "Player 2"
        takeTurn(strCurrentPlayer)
    End Sub
End Class
