const { describe } = require('mocha');
const { assert } = require('chai');

class PaymentPackage {
    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value    
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
            throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
            throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
            `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${this.value}`,
            `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}


describe('Payment package tests', () => {

    let instance = undefined;
    beforeEach(() => {
        instance = new PaymentPackage('Name', 100);
    })

    it('constructor', () => {
        assert.equal(instance._name, 'Name', '1');
        assert.equal(instance._value, 100, '2');
        assert.equal(instance._VAT, 20);
        assert.equal(instance._active, true);
    });
    it('name', () => {
        assert.equal(instance.name, 'Name');

        instance.name = 'Pesho';
        assert.equal(instance.name, 'Pesho');

        assert.throw(() => { instance.name = '' }, 'Name must be a non-empty string')
        assert.throw(() => { instance.name = 2 }, 'Name must be a non-empty string')
    });
    it('value', () => {
        assert.equal(instance.value, 100);
        assert.throw(() => { instance.value = 'string' }, 'Value must be a non-negative number')
        assert.throw(() => { instance.value = 0 }, 'Value must be a non-negative number')
        assert.throw(() => { instance.value = -20 }, 'Value must be a non-negative number')

        instance.value = 10;
        assert.equal(instance.value, 10)

    });
    it('VAT', () => {
        assert.equal(instance.VAT, 20)
        assert.throw(() => { instance.VAT = 'string' }, 'VAT must be a non-negative number')
        assert.throw(() => { instance.VAT = -20 }, 'VAT must be a non-negative number')
        assert.throw(() => { instance.VAT = 0 }, 'VAT must be a non-negative number')

        instance.VAT = 40;
        assert.equal(instance.VAT, 40)

    });
    it('active', () => {
        assert.equal(instance.active, true)
        assert.throw(() => { instance.active = undefined }, 'Active status must be a boolean')
        assert.throw(() => { instance.active = 'string' }, 'Active status must be a boolean')
        assert.throw(() => { instance.active = 20 }, 'Active status must be a boolean')
        assert.throw(() => { instance.active = [] }, 'Active status must be a boolean')
        assert.throw(() => { instance.active = {} }, 'Active status must be a boolean')

        instance.active = false;
        assert.equal(instance.active, false)


    });
    it('toString', () => {
        function getString(name, value, VAT, active){
            return [
                `Package: ${name}` + (active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${value}`,
                `- Value (VAT ${VAT}%): ${value * (1 + VAT / 100)}`
            ].join('\n');
        }

        assert.equal(instance.toString(), getString('Name', 100, 20, true))
        
        instance.active = false;
        assert.equal(instance.toString(), getString('Name', 100, 20, false))

        instance.VAT = 10;
        assert.equal(instance.toString(), getString('Name', 100, 10, false))

        instance.value = 50;
        assert.equal(instance.toString(), getString('Name', 50, 10, false))

        instance.name = 'NewName';
        assert.equal(instance.toString(), getString('NewName', 50, 10, false))

    });
})