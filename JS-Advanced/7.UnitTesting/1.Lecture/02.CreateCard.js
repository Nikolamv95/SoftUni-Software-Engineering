function createCard(face, suit) {

    const suitToString = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    const validFaces = ['1', '2', '3', '4', '5', '8', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    if (validFaces.includes(face) == false) {
        throw new Error('Invalid face');
    } else if (Object.keys(suitToString).includes(suit) == false) {
        throw new Error('Invalid suit');
    }

    return {
        face,
        suit,
        toString() {
            return `${face}${suitToString[suit]}`
        }
    }
}