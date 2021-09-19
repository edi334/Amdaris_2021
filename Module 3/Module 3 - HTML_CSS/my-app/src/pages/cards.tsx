import React, { useEffect, useState } from "react";
import {IPerson} from '../interfaces/IPerson';
import axios from "axios";
import SearchBar from './components/searchBar';
import PeopleList from './components/peopleList';


const Cards = () => {
    const [input, setInput] = useState('');
    const [peopleDefault, setPeopleDefault] = useState<IPerson[]>([]);
    const [people, setPeople] = useState<IPerson[]>([]);

    const fetchData = async () => {
        return await axios.get('https://swapi.dev/api/people')
            .then(response => {
                setPeople(
                    response.data.results
                );
                setPeopleDefault (
                    response.data.results
                )
        })
        .catch(error => {
            console.log(error);
        })
    }

    const updateInput = async (input: string) => {
        const filtered = peopleDefault.filter(person => {
            return person.name.toLowerCase().includes(input.toLowerCase())
        })
        setInput(input);
        setPeople(filtered);
     }

    useEffect( () => {fetchData()},[]);

    return (
        <>
            <h1>Star Wars People</h1>
            <SearchBar
                keyword={input}
                setKeyword={updateInput}
            />
            <PeopleList people={people}/>
        </>
    )
}

export default Cards;