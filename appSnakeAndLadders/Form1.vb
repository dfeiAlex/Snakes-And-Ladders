Public Class Form1
    Dim game = New Game()

    Private Sub btnDie1_Click(sender As Object, e As EventArgs) Handles btnDie1.Click
        Dim randomNumber As Integer = game.rollDie()
        game.setDiePic(randomNumber, picDie1)
    End Sub

    Private Sub btnDie2_Click(sender As Object, e As EventArgs) Handles btnDie2.Click
        Dim randomNumber As Integer = game.rollDie()
        game.setDiePic(randomNumber, picDie2)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picPlayer1.Parent = picBoard
        picPlayer2.Parent = picBoard
        picPlayer1.BackColor = Color.Transparent
        picPlayer2.BackColor = Color.Transparent

        picPlayer1.Left = lblCounter100.Left
        picPlayer1.Top = lblCounter100.Top

        picPlayer2.Top = lblCounter100.Bottom
        picPlayer2.Left = lblCounter100.Right
    End Sub
End Class
