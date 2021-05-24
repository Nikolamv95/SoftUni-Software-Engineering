function result(obj) {
    if (!['GET', 'POST', 'DELETE', 'CONNECT'].includes(obj.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'].includes(obj.version)) {
        throw new Error('Invalid request header: Invalid Version');
    };
    
    const regex = /^([a-zA-Z.]+)/gm;
    if (!obj.uri|| !regex.exec(obj.uri) || obj.uri !== '\*') {
        throw new Error('Invalid request header: Invalid Uri');
    }

    return obj;
};


let obj = result({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});

console.log(obj);