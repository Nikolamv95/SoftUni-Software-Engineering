const { expect, assert } = require('chai');
const sum = require('./sumNumbers');

describe('Sum numbers', () => {
    it('sums single number', () => {
        expect(sum([1])).to.equal(1);
    });

    it('sums single number', () => {
        expect(sum([1, 2])).to.equal(3);
    });

    it('sums single number', () => {
        expect(sum([1, 3, 4])).to.equal(8);
    });
})