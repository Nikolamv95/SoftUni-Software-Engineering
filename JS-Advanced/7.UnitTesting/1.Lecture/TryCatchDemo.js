function catcher(){
    try {
        //new Array(-1);
        throw new TypeError();
    } catch (er) {
        if (er instanceof RangeError) {
           console.log('Caught Range error')
        }else{
            throw er;
        }
    }
}

catcher();