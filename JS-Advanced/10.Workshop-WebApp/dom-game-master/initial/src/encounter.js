/* globals createElement, game */

Object.assign(window.game, (function () {

    return {
        encounterController,
        generateEncounter
    };

    function generateEncounter(difficalty) {
        let options = Object.entries(game.templates).filter(([k, v]) => v.ai == true);
        const selected = [];
        let encounterLevel = 0;

        while (encounterLevel < difficalty && options.length > 0) {
            const minLevel = Math.floor(difficalty / 3);
            const maxLevel = difficalty - encounterLevel;
            options = options.filter(([k, v]) => v.level <= maxLevel && v.level >= minLevel);

            const index = Math.floor(Math.random() * options.length);

            const current = options[index];
            encounterLevel += current[1].level;
            selected.push(game.createCharacter(current[0]));
        }

        return selected;
    }

    function encounterController(enemySlot, player) {
        let characters = [];
        let initiative;

        enemySlot.addEventListener('click', selectTarget);

        return {
            enter,
            onPlayerAttack,
            onEnemyAttack,
            selectTarget,
        };

        function onPlayerAttack() {
            enableTargetting(player);
        }

        function onEnemyAttack() {
            enableTargetting();
        }

        function selectTarget({ target }) {

            while (target != enemySlot && target.classList.contains('targettable') == false) {
                target = target.parentNode;
                if (target.classList === undefined) {
                    return;
                }
            }

            if (target.classList.contains('targettable')) {
                const selectedEnemy = characters.find(e => e.element == target);

                if (selectedEnemy) {
                    characters[initiative].character.attack(selectedEnemy.character);
                }
                disableTargetting();
                nextTurn();
            } else {
                disableTargetting();
            }
        };

        function enableTargetting(source) {
            characters
                .filter(characters => characters.character.alive && characters != source)
                .forEach(character => character.element.classList.add('targettable'));
        };

        function disableTargetting() {
            characters.forEach(character => character.element.classList.remove('targettable'));
        };

        function nextTurn() {
            if (player.character.alive == false) {
                game.events.onEncounterEnd(false);
            } else if (characters.filter(c => c.character.alive).length == 1) {
                game.events.onEncounterEnd(true);
            }

            do {
                initiative = (initiative + 1) % characters.length;
            } while (characters[initiative].character.alive == false);

            characters.forEach(c => c.element.classList.remove('active'));
            characters[initiative].element.classList.add('active');
            game.events.onBeginTurn(characters[initiative]);
        }

        function enter(enemies) {
            enemySlot.innerHTML = '';
            enemies.forEach(e => enemySlot.appendChild(e.element));
            characters = [player, ...enemies];
            initiative = -1;
            nextTurn();
        };
    };
})());
