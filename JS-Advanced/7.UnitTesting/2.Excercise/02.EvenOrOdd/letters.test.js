const { assert } = require('chai');
const isOddOrEven = require('./letters');


describe('Check is oddOrEven', ()=> {
    it('String is even', ()=> {
        assert.equal(isOddOrEven('string'), 'even');
    });
    it('String is odd', ()=> {
        assert.equal(isOddOrEven('strin'), 'odd');
    });
    it('String is undefined', ()=> {
        assert.equal(isOddOrEven(1), undefined);
    }); 
})