const { expect, assert } = require('chai');
const rgbToHexColor = require('./RBGtoHEX');

describe('RBGtoHEX', () => {
    it('convert black to hex', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal = ('#000000');
    });

    it('convert whie to hex', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal = ('#FFFFFF');
    });

    it('returns undefined for string params', () => {
        expect(rgbToHexColor('a', 'a', 'a')).to.be.undefined;
    });
})