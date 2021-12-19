import { Component, OnInit } from '@angular/core';
import { Square } from '../../models/square';
import { BoardService } from '../../services/board.service';
import { Board } from '../../models/board';
import { Move } from '../../models/move';
import { Checker } from '../../models/checker';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  count: number;
  board: Board;
  eight: number[];
  colores: string = 'yellow1';
  hovers: boolean;
  xx: number;
  yy: number;
  thatAreAvailable: number[];
  movies: Move[];
  lastX: number;
  lastY: number;
  lastAvailable: number[];
  lastMovies: Move[];
whoMoves: number;



  constructor(private boardService: BoardService) {
    //this.getBoard(3);
    //console.log(this.board);
  }

  ngOnInit() {
    this.whoMoves = 0;
    this.lastMovies = [];
    this.lastX = 0;
    this.lastY = 0;
    this.movies = [];
    this.lastAvailable = [64];
    this.thatAreAvailable = [64];
    this.eight = [];
    for (var _i = 0; _i < 8; _i++) {
      this.eight[_i] = (_i + 1);
    }
  }



  getAllCordinates() {

  }


  onCreateClick() {
    this.createBoard();
  }

  onLoadClick(id: number) {
    console.log(id);
    this.getBoard(id);
  }

  createBoard() {
    this.boardService.createBoard().subscribe(x => {
      this.board = x;
    });
  }
  getBoard(id: number) {
    this.boardService.getBoard(id).subscribe((x: Board) => {
      console.log(x);
      this.board = x;
      //console.log(x, this.board);
    },
      error => {
        console.log("erroras subscribe");
        console.error(error);
      });
  }
  getBoardStyle(x: number, y: number) {
    if ((x + y) % 2 == 0) {
      return "lightgoldenrodyellow";
    }
    else {
      return "brown";
    }
  }

  getCheckerStyle(color: number) {
    if (color == 0) {
      return "white";
    } else if (color == 1) {
      return "black";
    }
  }

  changeStyle($event, x: number, y: number) {
    this.colores = $event.type == 'mouseover' ? 'yellow' + ((x + (y - 1) * 8) - 1) : 'red' + ((x + (y - 1) * 8) - 1);
  }






  onSquareClick(x: number, y: number) {
    if(this.board.squares[x + (y - 1) * 8 - 1].checker != null && this.whoMoves == this.board.squares[x + (y - 1) * 8 - 1].checker.color || this.board.squares[x + (y - 1) * 8 - 1].checker == null)
    {
    if ((this.lastX != 0 && this.lastY != 0) && (this.lastX != x && this.lastY != y)
      && this.lastAvailable[x + (y - 1) * 8 - 1] != null && this.lastAvailable[x + (y - 1) * 8 - 1] != 0 ) {
      //console.log("praeina", this.lastAvailable);
      for (let move of this.lastMovies) {
        if (move.destX + 1 == x && move.destY + 1 == y) {

          this.board.squares[move.destX + 1 + (move.destY + 1 - 1) * 8 - 1].checker = this.board.squares[move.sourceX + 1 + (move.sourceY + 1 - 1) * 8 - 1].checker;
          this.board.squares[move.destX + 1 + (move.destY + 1 - 1) * 8 - 1].checkerId = this.board.squares[move.sourceX + 1 + (move.sourceY + 1 - 1) * 8 - 1].checkerId;
          //console.log(this.board);
          if (move.free) {
            // this.board.squares[move.sourceX+(move.sourceY-1)*8-1].checker = null;
            //this.board.squares[move.sourceX+(move.sourceY-1)*8-1].checkerId = null;
            this.whoMoves = (this.whoMoves + 1) % 2;
          }
          else if (move.knockX != 0 && move.knockY != 0) {
            var square = new Square;
square.checker = new Checker;
square.checker.color = this.board.squares[move.destX + 1 + (move.destY + 1 - 1) * 8 - 1].checker.color;
square.x = move.destX;
square.y = move.destY;
            this.board.squares[move.knockX + 1 + (move.knockY + 1 - 1) * 8 - 1].checker = null;
            this.board.squares[move.knockX + 1 + (move.knockY + 1 - 1) * 8 - 1].checkerId = null;
            console.log(this.Enemy(this.board, square));
            if(this.Enemy(this.board, square).length == 0)
            {
              
              this.whoMoves = (this.whoMoves + 1) % 2;
            }
          }
          this.board.squares[move.sourceX + 1 + (move.sourceY + 1 - 1) * 8 - 1].checker = null;
          this.board.squares[move.sourceX + 1 + (move.sourceY + 1 - 1) * 8 - 1].checkerId = null;
          this.lastAvailable = [];
          this.lastMovies = [];
          this.lastX = 0;
          this.lastY = 0;
          
        }
        /*else
        {
          this.lastAvailable = this.thatAreAvailable;
          this.lastMovies = this.movies;
          this.lastX = x;
          this.lastY = y;
        }*/
      }
    }
    else if(this.board.squares[x + (y - 1) * 8 - 1].checker != null){
      this.lastX = x;
      this.lastY = y;
      this.lastAvailable = this.thatAreAvailable;
      this.lastMovies = this.movies;
    }
  }
}


  removeMoves() {
    this.thatAreAvailable = [];
    this.movies = [];
  }

  getAllMoves(x: number, y: number) {

    if (this.board != null && this.board.squares != null
      && this.board.squares[(x + (y - 1) * 8) - 1] != null
      && this.board.squares[(x + (y - 1) * 8) - 1].checker != null
      && this.board.squares[(x + (y - 1) * 8) - 1].checker.color == this.whoMoves) {
      this.movies = [];
      var moves: Move[] = [];
      var square = this.board.squares[(x + (y - 1) * 8) - 1];
      if (this.board != null && this.board.squares[(square.x + 1 + (square.y) * 8) - 1].checker != null) {

        moves = moves.concat(this.Enemy(this.board, square));
        if (moves.length == 0) {
          moves = moves.concat(this.FreeMoves(this.board, square));

        }
        //console.log(square);
        this.movies = moves;
        for (let move of moves) {
          this.thatAreAvailable[(move.destX + 1 + (move.destY) * 8) - 1] = 1;
        }
      }
    }
  
  }


  FreeMoves(board: Board, source: Square) { // x 1    y 6
    var movys: Move[] = [];
    for (var _i = -1; _i < 2; _i += 2) {
      for (var _j = -1; _j < 2; _j += 2) {
        if (source.x + _i >= 0 && source.x + _i <= 7 && source.y + _j >= 0 && source.y + _j <= 7) {
          if (board.squares[((source.x + 1 + _i) + ((source.y + 1 + _j) - 1) * 8) - 1].checker == null) {
            if ((source.checker.color == 0 && _j < 0)
              || source.checker.color == 1 && _j > 0) {
              var move = new Move();

              move.sourceX = source.x;
              move.sourceY = source.y;
              move.destX = source.x + _i;
              move.destY = source.y + _j;
              move.free = true;

              movys.push(move);

            }
          }
        }
      }
    }
    //console.log("free ", movys);
    return movys;
  }

  Enemy(board: Board, source: Square) { // x-7 y-8
    var movys: Move[] = [];
    for (var i = -1; i < 2; i += 2) {
      for (var j = -1; j < 2; j += 2) {
        if (source.x + i > 0 && source.x + i < 7 && source.y + j > 0 && source.y + j < 7) {

          if (!(board.squares[((source.x + 1 + i) + ((source.y + 1 + j) - 1) * 8) - 1].checker == null ||
            board.squares[((source.x + 1 + i) + ((source.y + 1 + j) - 1) * 8) - 1].checker.color == source.checker.color || source.y + j * 2 > 7 ||
            source.x + i * 2 > 7 || source.y + j * 2 < 0 || source.x + i * 2 < 0 ||
            board.squares[((source.x + 1 + i * 2) + ((source.y + 1 + j * 2) - 1) * 8) - 1].checker != null)) {

            var move = new Move;

            move.sourceX = source.x;
            move.sourceY = source.y;
            move.destX = source.x + i * 2;
            move.destY = source.y + j * 2;
            move.free = false;
            move.knockX = source.x + i;
            move.knockY = source.y + j;

            movys.push(move);
            //console.log("source",source, move, board);
            //continue;
          }
        }


      }
    }
    //console.log("enemy ", movys);
    return movys;
  }
}
