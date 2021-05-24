const { assert } = require('chai');
const lookupChar = require('./charLookup');

describe('charLookup', ()=>{
    it('', () => {
        assert.equal(lookupChar(1, 1), undefined);
        assert.equal(lookupChar('abc', 1.2), undefined);
        assert.equal(lookupChar('abc', 'a'), undefined);
    });

    it('', () => {
        assert.equal(lookupChar('abv', -1), 'Incorrect index');
        assert.equal(lookupChar('abv', 3), 'Incorrect index');
    });

    it('', () => {
        assert.equal(lookupChar('abv', 0), 'a');
        assert.equal(lookupChar('abvg', 3), 'g');
    });
})