var __classPrivateFieldSet = (this && this.__classPrivateFieldSet) || function (receiver, state, value, kind, f) {
    if (kind === "m") throw new TypeError("Private method is not writable");
    if (kind === "a" && !f) throw new TypeError("Private accessor was defined without a setter");
    if (typeof state === "function" ? receiver !== state || !f : !state.has(receiver)) throw new TypeError("Cannot write private member to an object whose class did not declare it");
    return (kind === "a" ? f.call(receiver, value) : f ? f.value = value : state.set(receiver, value)), value;
};
var __classPrivateFieldGet = (this && this.__classPrivateFieldGet) || function (receiver, state, kind, f) {
    if (kind === "a" && !f) throw new TypeError("Private accessor was defined without a getter");
    if (typeof state === "function" ? receiver !== state || !f : !state.has(receiver)) throw new TypeError("Cannot read private member from an object whose class did not declare it");
    return kind === "m" ? f : kind === "a" ? f.call(receiver) : f ? f.value : state.get(receiver);
};
var _Game_board, _Game_turn, _Board_itemArray, _Board_emptyButtons;
class Tools {
    static parsePosition([y, x], len = 3) {
        return len * y + x;
    }
    static parseLocation(pos, len = 3) {
        return [parseInt(`${pos / len}`), pos % len];
    }
}
class Game {
    constructor(turn, board = new Board()) {
        _Game_board.set(this, void 0);
        _Game_turn.set(this, void 0);
        __classPrivateFieldSet(this, _Game_turn, turn, "f");
        __classPrivateFieldSet(this, _Game_board, board, "f");
    }
    get turn() {
        return __classPrivateFieldGet(this, _Game_turn, "f");
    }
    get board() {
        return __classPrivateFieldGet(this, _Game_board, "f").itemArray;
    }
    reset(turn, board = __classPrivateFieldGet(this, _Game_board, "f").reset()) {
        __classPrivateFieldSet(this, _Game_turn, turn, "f");
        __classPrivateFieldSet(this, _Game_board, board, "f");
        return this;
    }
    makeMove([y, x]) {
        __classPrivateFieldGet(this, _Game_board, "f").updateSquare([y, x], __classPrivateFieldSet(this, _Game_turn, __classPrivateFieldGet(this, _Game_turn, "f") * -1, "f"));
    }
}
_Game_board = new WeakMap(), _Game_turn = new WeakMap();
class Board {
    constructor(board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]) {
        _Board_itemArray.set(this, void 0);
        _Board_emptyButtons.set(this, void 0);
        __classPrivateFieldSet(this, _Board_itemArray, board, "f");
        __classPrivateFieldSet(this, _Board_emptyButtons, (() => {
            var out = [];
            for (var i = 0; i < board.length; i++)
                for (var j = 0; j < board[i].length; j++)
                    out.push(Tools.parsePosition([i, j]));
            return out;
        })(), "f");
    }
    get itemArray() {
        return __classPrivateFieldGet(this, _Board_itemArray, "f");
    }
    get emptyButtons() {
        return __classPrivateFieldGet(this, _Board_emptyButtons, "f");
    }
    reset() {
        __classPrivateFieldSet(this, _Board_itemArray, [[0, 0, 0], [0, 0, 0], [0, 0, 0]], "f");
        __classPrivateFieldSet(this, _Board_emptyButtons, [0, 1, 2, 3, 4, 5, 6, 7, 8], "f");
        return this;
    }
    updateSquare([y, x], val) {
        __classPrivateFieldGet(this, _Board_itemArray, "f")[y][x] = val;
    }
}
_Board_itemArray = new WeakMap(), _Board_emptyButtons = new WeakMap();