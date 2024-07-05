/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Member } from '../models/Member';
import type { MembershipLevel } from '../models/MembershipLevel';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class MembersService {
    /**
     * @returns Member OK
     * @throws ApiError
     */
    public static listMembers({
        level,
        nameSubString,
        age,
    }: {
        level?: MembershipLevel | null,
        nameSubString?: string | null,
        age?: number | null,
    }): CancelablePromise<Array<Member>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Members',
            query: {
                'Level': level,
                'NameSubString': nameSubString,
                'Age': age,
            },
        });
    }
    /**
     * @returns any Created
     * @throws ApiError
     */
    public static createMember({
        requestBody,
    }: {
        requestBody: Member,
    }): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Members',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @returns Member OK
     * @throws ApiError
     */
    public static getMember({
        id,
    }: {
        id: string,
    }): CancelablePromise<Member> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Members/{id}',
            path: {
                'id': id,
            },
            errors: {
                404: `Not Found`,
            },
        });
    }
    /**
     * @returns any OK
     * @throws ApiError
     */
    public static updateMember({
        id,
        requestBody,
    }: {
        id: string,
        requestBody: Member,
    }): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/Members/{id}',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @returns void
     * @throws ApiError
     */
    public static deleteMember({
        id,
    }: {
        id: string,
    }): CancelablePromise<void> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Members/{id}',
            path: {
                'id': id,
            },
        });
    }
}
