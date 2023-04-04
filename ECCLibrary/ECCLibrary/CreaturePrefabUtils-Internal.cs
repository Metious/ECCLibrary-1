﻿using ECCLibrary.Data;

namespace ECCLibrary;

/// <summary>
/// Utilities related to creating a creature prefab object.
/// </summary>
public static partial class CreaturePrefabUtils
{
    internal static SwimBehaviour AddSwimBehaviour(GameObject creature, SwimBehaviourData data, SplineFollowing splineFollowing)
    {
        var component = creature.EnsureComponent<SwimBehaviour>();
        component.turnSpeed = data.turnSpeed;
        component.splineFollowing = splineFollowing;
        return component;
    }

    internal static SwimRandom AddSwimRandom(GameObject creature, SwimRandomData data)
    {
        var component = creature.EnsureComponent<SwimRandom>();
        component.evaluatePriority = data.evaluatePriority;
        component.swimRadius = data.swimRadius;
        component.swimForward = data.swimForward;
        component.swimVelocity = data.swimVelocity;
        component.swimInterval = data.swimInterval;
        component.onSphere = data.onSphere;
        return component;
    }

    internal static Locomotion AddLocomotion(GameObject creature, LocomotionData data, BehaviourLOD levelOfDetail, Rigidbody rigidbody)
    {
        var component = creature.EnsureComponent<Locomotion>();
        component.levelOfDetail = levelOfDetail;
        component.useRigidbody = rigidbody;

        component.maxAcceleration = data.maxAcceleration;
        component.forwardRotationSpeed = data.forwardRotationSpeed;
        component.upRotationSpeed = data.upRotationSpeed;
        component.driftFactor = data.driftFactor;
        component.canMoveAboveWater = data.canMoveAboveWater;
        component.canWalkOnSurface = data.canWalkOnSurface;
        component.freezeHorizontalRotation = data.freezeHorizontalRotation;
        return component;
    }

    internal static SplineFollowing AddSplineFollowing(GameObject creature, Rigidbody rb, Locomotion locomotion, BehaviourLOD behaviourLOD)
    {
        var component = creature.EnsureComponent<SplineFollowing>();
        component.useRigidbody = rb;
        component.locomotion = locomotion;
        component.levelOfDetail = behaviourLOD;
        return component;

    }

    internal static LiveMixin AddLiveMixin(GameObject creature, LiveMixinData data)
    {
        var component = creature.EnsureComponent<LiveMixin>();
        component.data = data;
        return component;
    }

    internal static Eatable AddEatableComponent(GameObject go, EdibleData edibleData)
    {
        var eatable = go.EnsureComponent<Eatable>();
        eatable.foodValue = edibleData.foodAmount;
        eatable.waterValue = edibleData.waterAmount;
        eatable.kDecayRate = 0.015f * edibleData.decomposeSpeed;
        eatable.decomposes = edibleData.decomposes;
        return eatable;
    }

    internal static StayAtLeashPosition AddStayAtLeashPosition(GameObject creature, StayAtLeashData stayAtLeashData)
    {
        var component = creature.EnsureComponent<StayAtLeashPosition>();
        component.evaluatePriority = stayAtLeashData.evaluatePriority;
        component.leashDistance = stayAtLeashData.leashDistance;
        component.swimVelocity = stayAtLeashData.swimVelocity;
        component.swimInterval = stayAtLeashData.swimInterval;
        component.minSwimDuration = stayAtLeashData.minSwimDuration;
        return component;
    }

    internal static FleeOnDamage AddFleeOnDamage(GameObject creature, FleeOnDamageData data)
    {
        var component = creature.EnsureComponent<FleeOnDamage>();
        component.evaluatePriority = data.evaluatePriority;
        component.damageThreshold = data.damageThreshold;
        component.fleeDuration = data.fleeDuration;
        component.minFleeDistance = data.minFleeDistance;
        component.swimVelocity = data.swimVelocity;
        component.swimInterval = data.swimInterval;
        return component;
    }

    internal static Scareable AddScareable(GameObject creature, ScareableData data, CreatureFear fear, Creature creatureComponent, FleeWhenScared fleeWhenScared)
    {
        var component = creature.EnsureComponent<Scareable>();
        component.targetType = data.targetType;
        component.creatureFear = fear;
        component.creature = creatureComponent;
        component.fleeAction = fleeWhenScared;
        component.scarePerSecond = data.scarePerSecond;
        component.maxRangeScalar = data.maxRangeScalar;
        component.minMass = data.minMass;
        component.updateTargetInterval = data.updateTargetInterval;
        component.updateRange = data.updateRange;
        return component;
    }

    internal static AnimateByVelocity AddAnimateByVelocity(GameObject creature, AnimateByVelocityData data, Animator animator, Rigidbody rigidbody, BehaviourLOD behaviourLOD)
    {
        var component = creature.EnsureComponent<AnimateByVelocity>();
        component.animator = animator;
        component.animationMoveMaxSpeed = data.animationMoveMaxSpeed;
        component.animationMaxPitch = data.animationMaxPitch;
        component.animationMaxTilt = data.animationMaxTilt;
        component.useStrafeAnimation = data.useStrafeAnimation;
        component.rootGameObject = creature;
        component.dampTime = data.dampTime;
        component.levelOfDetail = behaviourLOD;
        return component;
    }

    internal static FleeWhenScared AddFleeWhenScared(GameObject creature, FleeWhenScaredData data, CreatureFear fear)
    {
        var component = creature.EnsureComponent<FleeWhenScared>();
        component.creatureFear = fear;
        component.exhausted = new CreatureTrait(0f, 0.05f);
        component.evaluatePriority = data.evaluatePriority;
        component.swimVelocity = data.swimVelocity;
        component.swimInterval = data.swimInterval;
        component.avoidanceIterations = data.avoidanceIterations;
        component.swimTiredness = data.swimTiredness;
        component.tiredVelocity = data.tiredVelocity;
        component.swimExhaustion = data.swimExhaustion;
        component.exhaustedVelocity = data.exhaustedVelocity;
        return component;
    }

    internal static CreatureFlinch AddCreatureFlinch(GameObject creature, Animator animator)
    {
        var component = creature.AddComponent<CreatureFlinch>();
        component.animator = animator;
        return component;
    }
}