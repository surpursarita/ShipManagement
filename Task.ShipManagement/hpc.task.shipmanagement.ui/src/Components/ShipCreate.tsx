import * as React from 'react';
import { Component, ChangeEvent } from 'react'
import ShipDataService from '../Services/Ship.Service';
import IShipData from '../Types/Ship.Type';

type Props = {};

type State = IShipData & {
    submitted: boolean
};

export default class ShipCreate extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeLength = this.onChangeLength.bind(this);
        this.onChangeWidth = this.onChangeWidth.bind(this);
        this.onChangeCode = this.onChangeCode.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.saveShip = this.saveShip.bind(this);
        this.newShip = this.newShip.bind(this);
        this.updateShip = this.updateShip.bind(this);
        this.deleteShip = this.deleteShip.bind(this);

        this.state = {
            name: '',
            length: 0,
            width: 0,
            code: '',
            description: '',
            submitted: false
        };
    }

    onChangeName(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            name: e.target.value
        });
    }

    onChangeLength(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            length: e.target.value ? Number(e.target.value) : 0
        });
    }

    onChangeWidth(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            width: e.target.value ? Number(e.target.value) : 0
        });
    }

    onChangeCode(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            code: e.target.value
        });
    }

    onChangeDescription(e: ChangeEvent<HTMLInputElement>) {
        this.setState({
            description: e.target.value
        });
    }

    saveShip() {
        const data: IShipData = {
            name: this.state.name,
            length: this.state.length,
            width: this.state.width,
            code: this.state.code,
            description: this.state.description
        };

        ShipDataService.create(data)
            .then((response: any) => {
                this.setState({
                    id: response.data.id,
                    name: response.data.name,
                    length: response.data.length,
                    width: response.data.width,
                    code: response.data.code,
                    description: response.data.description,                    
                    submitted: true
                });
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    }

    newShip() {
        this.setState({
            id: null,
            name: "",
            length: 0,
            width: 0,
            code: '',
            description: "",
            submitted: false
        });
    }

    updateShip() {
        const data: IShipData = {
            id: this.state.id,
            name: this.state.name,
            length: this.state.length,
            width: this.state.width,
            code: this.state.code,
            description: this.state.description
        };

        ShipDataService.update(data)
            .then((response: any) => {
                this.setState({
                    id: response.data.id,
                    name: response.data.name,
                    length: response.data.length,
                    width: response.data.width,
                    code: response.data.code,
                    description: response.data.description,
                    submitted: true
                });
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    }

    deleteShip() {
        ShipDataService.update(this.state.id)
            .then((response: any) => {
                this.setState({
                    id: null,
                    name: "",
                    length: 0,
                    width: 0,
                    code: '',
                    description: "",
                    submitted: false
                });
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    }

    render() {
        const { submitted } = this.state;       
        return (
            <div className="submit-form">
                {submitted ? (
                    <div>
                        <h4>You submitted successfully!</h4>
                        <button className="btn btn-success" onClick={this.newShip}>
                            Add
                        </button>
                        <button className="btn btn-success" onClick={this.updateShip}>
                            Update
                        </button>
                        <button className="btn btn-success" onClick={this.deleteShip}>
                            Update
                        </button>
                    </div>
                ) : (
                    <div>
                        <div className="form-group">
                            <label htmlFor="Name">Name</label>
                            <input type="text" className="form-control" placeholder='Please type Name' onChange={this.onChangeName} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Length">Length (meters)</label>
                            <input type="number" className="form-control" placeholder='Please Type Length' onChange={this.onChangeLength} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Width">Width (meters)</label>
                            <input type="number" className="form-control" placeholder='Please Type Width' onChange={this.onChangeWidth} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Code">Code</label>
                            <input type="text" className="form-control" placeholder='Please Type Code' onChange={this.onChangeCode} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Description">Description</label>
                            <input type="text" className="form-control" placeholder='Please Type Description' onChange={this.onChangeDescription} />
                        </div>
                        <div>
                            <button onClick={this.saveShip} type='submit' className="btn btn-success submit">Submit</button>
                        </div>
                    </div>
                )}
            </div>
        );
    }
}
            