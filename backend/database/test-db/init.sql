DROP TABLE IF EXISTS financify_user;
DROP TABLE IF EXISTS person;

CREATE TABLE person (
    id SERIAL PRIMARY KEY,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE
);

CREATE TABLE financify_user (
    id SERIAL PRIMARY KEY,
    person_id INTEGER NOT NULL UNIQUE,
    password TEXT NOT NULL,
    salt TEXT NOT NULL,
    FOREIGN KEY (person_id) REFERENCES person(id)
);