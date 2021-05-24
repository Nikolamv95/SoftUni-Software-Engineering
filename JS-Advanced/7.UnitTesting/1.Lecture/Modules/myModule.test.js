const { sum } = require('./myModule');
const { expect, assert } = require('chai');

describe('Sum function', () => {
    it(('works with numbers'), () => {
        assert.equal(sum(1, 2), 3)
        //or
        //expect(sum(1, 2)).to.equal(3);
    });

    it(('works with strings'), () => {
        expect(sum('1', '2')).to.equal(3);
    });

    it('return NaN with invalid values', () => {
        expect(sum('a', 'a')).to.be.NaN;
    })
});