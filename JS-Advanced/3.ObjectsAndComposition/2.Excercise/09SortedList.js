function createSortedList() {
    let list = [];

    function add(element) {
        list.push(element);
        list.sort((a, b) => a - b);
        this.size++;
    }

    function remove(index) {
        if (index >= 0 && index < list.length) {
            list.splice(index, 1);
            this.size--;
        }
    }

    function get(index) {
        if (index >= 0 && index < list.length) {
            return list[index];
        }
    }

    // the name of the property and the name of the function should be similar
    // property add -> function add
    return {
        add,
        remove,
        get,
        size: 0,
    };
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
