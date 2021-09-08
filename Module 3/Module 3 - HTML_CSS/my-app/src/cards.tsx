import React from "react";
import './cards.css';
import axios from "axios";
import {IPerson} from './IPerson';
import Card from './card'


interface ICardsProps {
    
}

interface ICardsState {
    people: IPerson[];
}

class Cards extends React.Component<ICardsProps, ICardsState> {
    constructor(props: ICardsProps) {
        super(props as any);
        this.state = {
            people: []
        }
    }

    componentDidMount() {
        axios.get('https://swapi.dev/api/people')
            .then(response => {
                this.setState({
                    people: response.data.results
                  });
        })
            .catch(error => {
                console.log(error);
        })
    }

    logPeople = () => {
        console.log(this.state.people);
    }

    render() {
        const people = this.state.people;
        return (
            <div>
                {
                    people.map(person => (
                        <Card person={person}></Card>
                    ))
                }
            </div>
        );
    }
}

export default Cards;