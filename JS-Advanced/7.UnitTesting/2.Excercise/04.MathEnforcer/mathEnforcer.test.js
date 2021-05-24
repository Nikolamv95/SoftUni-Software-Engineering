const { assert } = require('chai');
const mathEnforcer = require('./mathEnforcer');


describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('is not number', () => {
            assert.equal(mathEnforcer.addFive('a'), undefined);
        });
        it('add properly', () => {
            assert.equal(mathEnforcer.addFive(0), 2, 'here write message');
            assert.equal(mathEnforcer.addFive(-5), 0);
            assert.equal(mathEnforcer.addFive(1.2), 6.2);
            assert.equal(mathEnforcer.addFive(1), 6);
        });
    });
    describe('subtractTen', () => {
        it('is not number', () => {
            assert.equal(mathEnforcer.subtractTen('a'), undefined)
        });
        it('subtract properly', () => {
            assert.equal(mathEnforcer.subtractTen(10), 0);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
            assert.equal(mathEnforcer.subtractTen(1.2), -8.8);
            assert.equal(mathEnforcer.subtractTen(20), 10);
        });
    });
    describe('sum', () => {
        it('is not number', () => {
            assert.equal(mathEnforcer.sum('a', 1), undefined)
            assert.equal(mathEnforcer.sum('1', 1), undefined)
            assert.equal(mathEnforcer.sum(1, '1'), undefined)
            assert.equal(mathEnforcer.sum('1', '1'), undefined)
        });
        it('sum properly', () => {
            assert.equal(mathEnforcer.sum(1, 1), 2)
            assert.equal(mathEnforcer.sum(-1, 1), 0)
            assert.equal(mathEnforcer.sum(-1, -1), -2)
            assert.equal(mathEnforcer.sum(1.2, 1), 2.2)
        });
    });
});