/* globals createElement, game */

Object.assign(window.game, (function () {

    const templates = {
        player: {
            name: 'Warrior',
            img: 'player.png',
            hp: 100,
            dmg: 25,
            defense: 10,
            attackRating: 10,
        },
        rat: {
            name: 'Giant Rat',
            level: 1,
            ai: true,
            img: 'rat.png',
            hp: 30,
            dmg: 10,
            defense: 5,
            attackRating: 3,
        },
        skeleton: {
            name: 'Skeleton',
            level: 2,
            ai: true,
            img: 'skeleton.png',
            hp: 50,
            dmg: 15,
            defense: 8,
            attackRating: 5,
        },
        goblin: {
            name: 'Goblin',
            level: 4,
            ai: true,
            img: 'goblin.png',
            hp: 100,
            dmg: 25,
            defense: 12,
            attackRating: 10,
        },
    };

    return {
        templates,
        createCharacter
    };

    function createCharacter(type) {
        const character = Object.assign({
            alive: true,
            attack,
            takeDamage,
        }, templates[type]);
        character.maxHp = character.hp;

        const element = createCharacterCard(character);

        return {
            character,
            element,
        };

        function attack(target) {
            console.log(`${character.name} attacks ${target.name} for ${character.dmg}`);
            const chance = Math.min(character.attackRating / target.defense, 1);

            if (chance >= Math.random()) {
                target.takeDamage(character.dmg);
            } else {
                console.log('Attack misses!')
            }
        };

        function takeDamage(incomingDmg) {
            console.log(`${character.name} took ${incomingDmg} damage.`);
            character.hp -= incomingDmg;
            if (character.hp <= 0) {
                character.hp = 0;
                character.alive = false;
            }
            element.update();
        };
    }

    function createCharacterCard(character) {
        const stats = {
            hp: createElement('span', {}, `${character.hp} / ${character.maxHp}`),
        };

        const element = createElement('article', { className: `character-card` },
            createElement('div', { className: `portrait` }, createElement('img', { src: `assets/` + character.img })),
            createElement('div', { className: `description` },
                createElement('h3', {}, character.name),
                createElement('ul', { className: `stats` },
                    createElement('li', {}, 'HP: ', stats.hp),
                    createElement('li', {}, 'Damage: ', createElement('span', {}, `${character.dmg}`)),
                ),
            )
        );

        element.update = update;

        return element;

        function update() {
            stats.hp.textContent = `${character.hp} / ${character.maxHp}`;
            if (character.alive == false) {
                element.classList.add(`wasted`);
            }
        };
    };
})());