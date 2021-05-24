const { expect, assert } = require('chai');
const isSymmetric = require('./isSymmetric');

describe('isSymmetric', () => {
    it('returns true for valid symmetric input', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('returns false for not valid symmetric input', () => {
        expect(isSymmetric([1,2])).to.be.false;
    });

    it('returns false for invalid arguments', () =>{
        expect(isSymmetric('a')).to.be.false;
    });

    it('returns true for valid symmetric odd-elements array', () =>{
        expect(isSymmetric([1,1,1])).to.be.true;
    });

    it('returns true for valid symmetric string array', () =>{
        expect(isSymmetric([1,1,1])).to.be.true;
    });

    it('returns false for type-coerced elements', () =>{
        expect(isSymmetric([1, '1'])).to.be.false;
    });
})
