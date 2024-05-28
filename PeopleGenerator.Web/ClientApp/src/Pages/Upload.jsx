import { useRef } from "react"
import toBase64 from "../services/toBase64";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function Upload() {
    const fileRef = useRef();
    const navigate = useNavigate();

    const onUploadClick = async e => {
        e.preventDefault();
        if (!fileRef.current.files.length) {
            return;
        }
        const base64 = await toBase64(fileRef.current.files[0]);
        console.log(base64);
        await axios.post('/api/people/upload', { base64 });
        navigate('/');
    }

    return <>
        <div className="row"><div className="col-md-10">
            <input ref={fileRef} type="file" className="form-control" />
        </div>
            <div className="col-md-2">
                <button onClick={onUploadClick} className="btn btn-primary">Upload</button>
            </div>
        </div>
    </>
}