import PeopleTable from "../components/PeopleTable"
import { useState, useEffect } from "react"
import axios from "axios";

export default function Home() {
    const [people, setPeople] = useState([]);

    const onDeleteAllClick = async () => {
        await axios.post('/api/people/deleteAll');
        setPeople([]);
    }

    useEffect(() => {
        (async function () {
            const { data } = await axios.get('/api/people/getAll');
            setPeople(data);
        })();
    }, [])

    return <>
        <div className="text-center">
            <button onClick={onDeleteAllClick} className="btn btn-danger w-25">
                Delete All
            </button>
            <PeopleTable people={people} />
        </div>
    </>
}