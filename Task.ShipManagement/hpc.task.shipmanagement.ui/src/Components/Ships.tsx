import * as React from 'react';
import { Component } from 'react';
import { Container, Row, Col } from 'react-grid-system';
import ShipDataService from '../Services/Ship.Service';


export default class Ships extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {
            shipdetails: []
        };
    }
    
    componentDidMount() {
        //this.ShipList();
    }

    //ShipList() {
    //    ShipDataService.getAll()
    //        .then((response: any) => {
    //            this.setState({
    //                shipdetails: response.data
    //            });
    //            console.log(response.data);
    //        })
    //        .catch((e: Error) => {
    //            console.log(e);
    //        });
    //}

    render() {
        return (
            <Container>
                <Row>
                    <Col sm={2}>
                        <label>Name</label>
                    </Col>
                    <Col sm={2}>
                        <label>Length (meters)</label>
                    </Col>
                    <Col sm={2}>
                        <label>Width (meters)</label>
                    </Col>
                    <Col sm={2}>
                        <label>Code</label>
                    </Col>
                    <Col sm={4}>
                        <label>Description</label>
                    </Col>
                </Row>
                <Row>
                    <Col sm={2}>
                        <label>Name</label>
                    </Col>
                    <Col sm={2}>
                        <label>Length (meters)</label>
                    </Col>
                    <Col sm={2}>
                        <label>Width (meters)</label>
                    </Col>
                    <Col sm={2}>
                        <label>Code</label>
                    </Col>
                    <Col sm={4}>
                        <label>Description</label>
                    </Col>
                </Row>
            </Container>
        )
    }
}