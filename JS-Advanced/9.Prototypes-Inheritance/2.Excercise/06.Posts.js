function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    };

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content)
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString();
            let rating = `Rating: ${this.likes - this.dislikes}`
            let comments = this.comments.length > 0 ? `Comments:\n${this.comments.map(comment => `* ${comment}`).join(`\n`)}` : '';
            return [
                result, 
                rating, 
                comments
            ].join(`\n`).trim();
        }
    };

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content)
            this.views = views;
        }

        view() {
            this.views++;
            return this; // returns the BlogPost object with the updated views data; Similar BlogPost object every time when te function is called for the current instance;
        };

        toString() {
            return super.toString() + `\nViews: ${this.views}`;
        };
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
}

let p = solve();
let blog = new p.BlogPost('title', 'aaaaa', 10);
let blog2 = new p.BlogPost('title', 'aaaaa', 0);

blog.view().view().view();
console.log(blog.views)

blog2.view().view().view();
console.log(blog2.views)