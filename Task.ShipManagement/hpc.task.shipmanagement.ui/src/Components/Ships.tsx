import * as React from 'react';
import { Component } from 'react';
import { Container, Row, Col, Hidden  } from 'react-grid-system';
import ShipDataService from '../Services/Ship.Service';
import IShipData from '../Types/Ship.Type';

export default class Ships extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {
            shipdetails: []
        };
    }
    
    componentDidMount() {
        this.ShipList();
    }

    ShipList() {
        ShipDataService.getAll()
            .then((response: any) => {
                this.setState({
                    shipdetails: response.data
                });
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    }

    render() {
        const { shipdetails } = this.state.shipdetails;
        return (
            <div>
                
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
                    {shipdetails ? (
                        shipdetails.forEach((shipDetail: IShipData) => {
                        <Row>
                            <Hidden xs sm>
                                <label>shipDetail.Id</label>
                            </Hidden>
                            <Col sm={2}>
                                <label>shipDetail.Name</label>
                            </Col>
                            <Col sm={2}>
                                <label>shipDetail.Length</label>
                            </Col>
                            <Col sm={2}>
                                <label>shipDetail.Width</label>
                            </Col>
                            <Col sm={2}>
                                <label>shipDetail.Code</label>
                            </Col>
                            <Col sm={4}>
                                <label>shipDetail.Description</label>
                            </Col>
                        </Row>
                    })
                    ) : null}
            </Container>
        </div>
        );
    }
}