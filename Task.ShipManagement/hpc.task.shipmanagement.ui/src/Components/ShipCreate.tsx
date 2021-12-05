import * as React from 'react';
import { useState } from 'react';

export default function ShipCreate() {
    const [name, setName] = useState('');
    const [length, setLength] = useState(0);
    const [width, setWidth] = useState(0);
    const [code, setCode] = useState('');
    const [description, setDescription] = useState('');
    //const [error, setError] = useState(null);
    const postData = () => {
        console.log(name);
        console.log(length);
        console.log(width);
        console.log(code);
        console.log(description);
    }
    return (
        <form className="create-form">
            <div>
                <label>Name</label>
            </div>
            <div>
                <input type="text" placeholder='Please type Name' onChange={(e) => setName(e.target.value)} />
            </div>
            <div>
                <label>Length (meters)</label>
            </div>
            <div>
                <input type="number" placeholder='Please Type Length' onChange={(e) => setLength(e.target.value ? Number(e.target.value) : 0)} />
            </div>
            <div>
                <label>Width (meters)</label>
            </div>
            <div>
                <input type="number" placeholder='Please Type Width' onChange={(e) => setWidth(e.target.value ? Number(e.target.value) : 0)} />
            </div>
            <div>
                <label>Code</label>
            </div>
            <div>
                <input type="text" placeholder='Please Type Code' onChange={(e) => setCode(e.target.value)} />
            </div>
            <div>
                <label>Description</label>
            </div>
            <div>
                <input type="text" placeholder='Please Type Description' onChange={(e) => setDescription(e.target.value)} />
            </div>
            <div>
                <button onClick={postData} type='submit'>Submit</button>
            </div>
        </form>
    )
}