import { useState } from "react"
import axios from "axios"

export default function Generate() {
    const [amount, setAmount] = useState(0);

    const onSubmit = async e => {
        e.preventDefault();
        await axios.post('/api/people/generate', { amount });
        window.location.href = '/api/people/getGeneratedPeople';
        // window.location.href = `/api/people/generate?amount=${amount}`;
    }

    return <>
        <form onSubmit={onSubmit}>
            <div className="row"><div className="col-md-10">
                <input type="number" className="form-control"
                    value={amount} onChange={e => setAmount(e.target.value)} />
            </div>
                <div className="col-md-2">
                    <button className="btn btn-primary">Upload</button>
                </div>
            </div>
        </form>
    </>
}