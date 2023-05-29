class Tools {
  public static parsePosition([y, x]: [number, number], len: number = 3) {
    return len * y + x;
  }

  public static parseLocation(pos: number, len: number = 3) {
    return [parseInt(`${pos / len}`), pos % len];
  }
}

class Game {
  #board: Board;
  #turn: number;

  constructor(turn: number, board: Board = new Board()) {
    this.#turn = turn;
    this.#board = board;
  }

  public get turn() {
    return this.#turn;
  }

  public get board() {
    return this.#board.itemArray;
  }

  public reset(turn: number, board: Board = this.#board.reset()) {
    this.#turn = turn;
    this.#board = board;
    return this;
  }

  public makeMove([y, x]: [number, number]) {
    this.#board.updateSquare([y, x], this.#turn *= -1);
  }
}

class Board {
  #itemArray: number[][];
  #emptyButtons: number[];

  public constructor(board: number[][] = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]) {
    this.#itemArray = board;
    this.#emptyButtons = (() => {
      var out: number[] = [];
      for (var i: number = 0; i < board.length; i++)
        for (var j: number = 0; j < board[i].length; j++)
          out.push(Tools.parsePosition([i, j]));
      return out;
    })();
  }

  public get itemArray() {
    return this.#itemArray;
  }

  public get emptyButtons() {
    return this.#emptyButtons;
  }

  public reset() {
    this.#itemArray = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
    this.#emptyButtons = [0, 1, 2, 3, 4, 5, 6, 7, 8];
    return this;
  }

  public updateSquare([y, x]: [number, number], val: number) {
    this.#itemArray[y][x] = val;
  }
}