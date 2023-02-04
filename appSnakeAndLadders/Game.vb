Public Class Game
    Dim RNG = New Random()

    'Keeps track of player scores
    Public player1Score As Integer = 1
    Public player2Score As Integer = 1

    'Keeps track of whether they have rolled a 6 (started playing)
    Public player1Playing As Boolean = False
    Public player2Playing As Boolean = True

    'Generate a number between 1 and 6
    Private Function rollDie() As Integer
        Return RNG.Next(1, 7) 'Return a number from 1 to 6
    End Function
End Class