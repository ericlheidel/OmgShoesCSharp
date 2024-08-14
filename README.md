OMG, Shoes... is currently deployed,
[www.omgshoes.eheidel.com](http://www.omgshoes.eheidel.com), please give it e
visit and read more about the deployment down below.

# Welcome to OMG, Shoes...

OMG, Shoes... is a community for sneaker enthusiasts to keep track of their
sneaker collection and view and discuss collections with other users.

# Technical

This version of OMG, Shoes... is a C#/.NET api version of my Nashville Software
School front end, JSON server, [capstone project](https://github.com/ericlheidel/omg-shoes). The front end is
written in Reactjs, the back end is written in C#/.NET, and the database is
through PostgreSQL16.

Having written this project's front end in Reactjs, it currently acts as an SPA
(Single Page Application). I am currently working on a Next.js version of this
project that I will also deploy, in hopes to showcase my React growth into non-SPA's.

# Deployment

This was my first real-deal deployment and I worked through it by myself, failing,
triumphing, and failing again. After enough trial and error, researching, and reading docs,
I feel confident that I could do this all on my own again, much more quickly.

I decided to dive into learning how to deploy and host my own domain and projects myself.
I landed on using a DigitalOcean Droplet running Ubuntu 24.04.
- Frontend Deployment
  - The Reactjs portion of the project was built with `npm`
  - `Nginx 1.24.0` is being used as a reverse proxy, is serving the files,
   and is routing the API requests.
- Backend Deployment
  - `dotnet` to build and publish the API.
  - `dotnet efcore` for Migrations.
  - `systemd` manages the API lifecycle
- Database
  - `postgresql@16` is running a dedicated cluster

<small style="font-size: 0.6em; color: gray;">**Disclaimer:**

This project, including all images, characters, and content, is intended solely
for educational and non-commercial purposes. The use of images and references to
any existing products or pop culture references is intended as a parody and does
not imply any endorsement or affiliation with the respective copyright holders.

All trademarks, images, and characters referenced within this project are the
property of their respective copyright holders. The use of such materials is
protected under the principles of fair use and free speech. No copyright
infringement is intended.

Users of this project should be aware that the project owner does not claim
ownership of any copyrighted materials referenced herein, and no profit is being
made from the distribution or use of this project. </small>
